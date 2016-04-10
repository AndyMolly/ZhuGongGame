using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class PanelMgr  {

    #region  初始化
    protected static PanelMgr mInstance;
    public static PanelMgr Instance
    {
        get
        {
            if (mInstance == null)
            {
                mInstance = new PanelMgr(); 
            }
            return mInstance;
        }
    }
    private PanelMgr()
    {
        panels = new Dictionary<PanelType, PanelBase>();
    }
    void Destory()
    {
        panels.Clear();
        panels = null;
    }
    #endregion
    #region 数据定义
    public Dictionary<PanelType, PanelBase> panels;
    public enum PanelShowStyle
    { 
        Nomal, 
        CenterScaleBigNormal,
        TopToSlide,
        BottomToSlide,
        LeftToSlide,
        RightToSlide
    }
    public enum PanelMaskStyle
    { 
        None,
        BlackAlpha,
        Alpha,
    }
    #endregion
    private Transform parentObj = null;
    private PanelBase current=null; //当前打开的面板
    public void ShowPanel(PanelType panelType, params object[] panelArgs)
    {
        if (panels.ContainsKey(panelType))
        {
            Debug.Log("该面板已打开");
            current = panels[panelType];
            current.gameObject.SetActive(false);
            //current.Init();
            current.OnInit(panelArgs);
        }
        else
        {
            string name = panelType.ToString();
            GameObject scene = new GameObject(name);
            current = scene.AddComponent(Type.GetType(name)) as PanelBase;

            //current.Init();
            current.OnInit(panelArgs);
            panels.Add(panelType,current);
        
            if (parentObj == null)
            {
                parentObj = GameObject.Find("UI Root").transform;
            }
            scene.transform.parent = parentObj;
            scene.transform.localEulerAngles = Vector3.zero;
            scene.transform.localScale = Vector3.one;
            scene.transform.localPosition = Vector3.zero;

            LayerMgr.GetInstance().SetLayer(current.gameObject, LayerType.Panel);
        }
        

        StartShowPanel(current, current.panelShowStyle, true);
    }
    /// <summary>
    /// 关闭
    /// </summary>
    /// <param name="panelType"></param>
    public void HidePanel(PanelType panelType)
    {
        if (panels.ContainsKey(panelType))
        {
            PanelBase pb = null;
            pb = panels[panelType];
            StartShowPanel(current, pb.panelShowStyle, false);
        }
        else
        {
            
        }
    }
    /// <summary>
    /// 强制删除面板
    /// </summary>
    /// <param name="panelType"></param>
    public void DestoryPanel(PanelType panelType)
    {
        if (panels.ContainsKey(panelType))
        {
            PanelBase pb = panels[panelType];
            GameObject.Destroy(pb.gameObject);
            panels.Remove(panelType);
        }
    }
    private void StartShowPanel(PanelBase go, PanelShowStyle showStyle, bool isOpen)
    {
        switch (showStyle)
        { 
            case PanelShowStyle.Nomal:
                ShowNormal(go, isOpen);
                break;
            case PanelShowStyle.CenterScaleBigNormal:
                ShowCenterScaleBigNormal(go, isOpen);
                break;
            case PanelShowStyle.LeftToSlide:
                ShowLeftToSLide(go, isOpen, true);
                break;
            case PanelShowStyle.RightToSlide:
                ShowLeftToSLide(go, isOpen, false);
                break;
            case PanelShowStyle.TopToSlide:
                ShowTopToSlide(go, isOpen, true);
                break;
            case PanelShowStyle.BottomToSlide:
                ShowTopToSlide(go, isOpen, false);
                break;
        }
    }
    #region 各种打开效果
    void ShowNormal(PanelBase go, bool isOpen)
    {
        if (!isOpen)
        {
            DestoryPanel(go.type);
        }
        else
        {
            go.gameObject.SetActive(true);
        }
    }
    void ShowCenterScaleBigNormal(PanelBase go,bool isOpen)
    {
        TweenScale ts = go.gameObject.GetComponent<TweenScale>();
        if (ts == null) ts=go.gameObject.AddComponent<TweenScale>();
        ts.from = Vector3.zero;
        ts.to = Vector3.one;
        ts.duration = go.openDuration; ;
        ts.SetOnFinished(() => {
            if (!isOpen)
            {
                DestoryPanel(go.type);
            }
        });
        go.gameObject.SetActive(true);
        if (!isOpen) ts.Play(isOpen);
    }
    /// <summary>
    /// 左右往中
    /// </summary>
    /// <param name="go"></param>
    /// <param name="isOpen"></param>
    /// <param name="isLeft"></param>
    void ShowLeftToSLide(PanelBase go, bool isOpen, bool isLeft)
    {
        TweenPosition tp = go.gameObject.GetComponent<TweenPosition>();
        if (tp == null) tp = go.gameObject.AddComponent<TweenPosition>();
        tp.from = isLeft ? new Vector3(-700, 0, 0) : new Vector3(700, 0, 0);
        tp.to = Vector3.zero;
        tp.duration = go.openDuration;
        tp.SetOnFinished(() =>
        {
            if (!isOpen)
            {
                DestoryPanel(go.type);
            }
        });
        go.gameObject.SetActive(true);
        if (!isOpen) tp.Play(isOpen);
    }
    /// <summary>
    /// 上下往中
    /// </summary>
    /// <param name="go"></param>
    /// <param name="isOpen"></param>
    /// <param name="isTop"></param>
    void ShowTopToSlide(PanelBase go, bool isOpen, bool isTop)
    {
        TweenPosition tp = go.gameObject.GetComponent<TweenPosition>();
        if (tp == null) tp = go.gameObject.AddComponent<TweenPosition>();
        tp.from = isTop ? new Vector3(0, 500, 0) : new Vector3(0, -500, 0);
        tp.to = Vector3.zero;
        tp.duration = go.openDuration;
        tp.SetOnFinished(() =>
        {
            if (!isOpen)
            {
                DestoryPanel(go.type);
            }
        });
        go.gameObject.SetActive(true);
        if (!isOpen) tp.Play(isOpen);
    }
    #endregion
}
