using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class LayerMgr : MonoBehaviour
{
    #region 初始化
    private static LayerMgr _instance;
    public static LayerMgr GetInstance()
    {
        if (_instance == null)
        {
            _instance = new GameObject("LayerMgr").AddComponent<LayerMgr>();
        }
        return _instance;
    }
    private LayerMgr()
    {
        layers = new Dictionary<LayerType, GameObject>();
    }
    void OnDestroy()
    {
        layers.Clear();
        layers = null;
    }
    #endregion

    private Dictionary<LayerType, GameObject> layers;
    private Transform parent;
    public void SetLayer(GameObject current,LayerType layerType)
    {
        if (layers.Count < Enum.GetNames(typeof(LayerType)).Length)
        { 
           //初始化层次
            LayerInit();
        }
        current.transform.parent = layers[layerType].transform;
        UIPanel[] panels = current.GetComponentsInChildren<UIPanel>(true);
        foreach (UIPanel panel in panels)
        {
            panel.depth += (int)layerType;
        }
    }
    public void LayerInit()
    {
        parent = GameObject.Find("UI Root").transform;
        int num = Enum.GetNames(typeof(LayerType)).Length;
        for (int i = 0; i < num; i++)
        {
            object obj = Enum.GetValues(typeof(LayerType)).GetValue(i);
            layers.Add((LayerType)obj, CreateLayerGameObject(obj.ToString(), (LayerType)obj));
        }
    }
    private GameObject CreateLayerGameObject(string name, LayerType type)
    {
        GameObject layer = new GameObject(name);
        layer.transform.parent = this.parent;
        layer.transform.localEulerAngles = Vector3.zero;
        layer.transform.localScale = Vector3.one;
        layer.transform.localPosition = new Vector3(0, 0, ((int)type)*(-1));
        return layer;
    }
}

public enum LayerType
{ 
    Scene=50, //场景
    Panel=200, //面板
    Tips=400, //提示
    Notice=1000 //公告
}
