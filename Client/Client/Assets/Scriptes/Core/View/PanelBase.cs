using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PanelBase : UIBase {

    protected PanelType _type;
    public PanelType type
    {
        get { return _type; }
    }
    /// <summary>
    /// 面板打开时间
    /// </summary>
    protected float _openDuration = 0.2f;
    public float openDuration
    {
        get { return _openDuration; }
    }
    protected PanelMgr.PanelShowStyle _showStyle = PanelMgr.PanelShowStyle.CenterScaleBigNormal;
    /// <summary>
    /// 面板显示方式
    /// </summary>
    public PanelMgr.PanelShowStyle panelShowStyle
    {
        get { return _showStyle; }
    }
    public virtual void OnInit(params object[] sceneArgs)
    {
        _sceneArgs = sceneArgs;
        Init();
    }
    #region 页面处理方法
    protected void Close()
    {
        //Destroy(this.gameObject);
        PanelMgr.Instance.HidePanel(_type);
    }
    protected void CloseImmediate()
    {
        PanelMgr.Instance.DestoryPanel(_type);
    }
    #endregion


}
public enum PanelType
{
    //玩家信息面板
    PanelPlayInfo,
    PanelShop
}
