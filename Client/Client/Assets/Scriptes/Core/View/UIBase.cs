using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UIBase : MonoBehaviour {

    void Start()
    {
        OnStart();
    }
    void Update()
    {
        OnUpdate();
    }
    /// <summary>
    /// 皮肤
    /// </summary>
    private GameObject _skin;
    public GameObject Skin
    {
        get { return _skin; }
    }
    public Transform SkinTransform
    {
        get
        {
            return _skin.transform;
        }
    }
    /// <summary>
    /// 主皮肤路径
    /// </summary>
    private string mainSkinPath;
    /// <summary>
    /// 设置主皮肤
    /// </summary>
    /// <param name="path"></param>
    protected void SetMainSkinPath(string path)
    {
        mainSkinPath = path;
    }
    /// <summary>
    /// 场景参数
    /// </summary>
    protected object[] _sceneArgs;
    public object[] SecneArgs
    {
        get { return _sceneArgs; }
    }

    private List<Collider> colliderList = new List<Collider>();

    public void OnDestroy()
    {
        OnDestroyFront();
        colliderList.Clear();
        colliderList = null;
        OnDestroyEnd();

    }
    public void Init()
    {
        OnInit();
        OnInitSkin();
        OnInitSkinDone();

        Collider[] colliders = this.gameObject.GetComponentsInChildren<Collider>(true);
        for (int i = 0; i < colliders.Length; i++)
        {
            Collider collider = colliders[i];
            UIEventListener listenser = UIEventListener.Get(collider.gameObject);
            listenser.onClick += OnClick;
            colliderList.Add(collider);
        }

        OnInitDone();
    }
    #region 虚方法

    protected virtual void OnStart() { }
    protected virtual void OnUpdate() { }
    /// <summary>
    /// 初始化
    /// </summary>
    protected virtual void OnInit() { }
    protected virtual void OnInitDone() { }
    /// <summary>
    /// 开始删除
    /// </summary>
    protected virtual void OnDestroyFront() { }
    /// <summary>
    /// 删除完成
    /// </summary>
    protected virtual void OnDestroyEnd() { }
    /// <summary>
    /// 点击事件
    /// </summary>
    /// <param name="click"></param>
    protected virtual void OnClick(GameObject click) { }
    /// <summary>
    /// 初始化皮肤
    /// </summary>
    protected virtual void OnInitSkin()
    {
        if (!string.IsNullOrEmpty(mainSkinPath))
        {
            _skin = ResourcesMgr.GetInstance().CreateGameObject(mainSkinPath, false);
        }
        _skin.transform.parent = this.transform;
        _skin.transform.localEulerAngles = Vector3.zero;
        _skin.transform.localScale = Vector3.one;
        _skin.transform.localPosition = Vector3.zero;
    }
    /// <summary>
    /// 初始化皮肤完成
    /// </summary>
    protected virtual void OnInitSkinDone() { }
    #endregion

}
