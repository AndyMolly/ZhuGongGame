using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SceneBase : UIBase {


    /// <summary>
    /// 初始化场景
    /// </summary>
    /// <param name="sceneArgs"></param>
    public virtual void OnInit(params object[] sceneArgs)
    {
        _sceneArgs = sceneArgs;
        Init();
    }
    public virtual void OnShowing()
    { 
    
    }
    /// <summary>
    /// 重置数据
    /// </summary>
    /// <param name="sceneArgs"></param>
    public virtual void OnResetArgs(params object[] sceneArgs)
    {
        _sceneArgs = sceneArgs;
    }
}
public enum SceneType
{
    SceneLogin,
    SceneHome,
    SceneLoading,
    SceneMail,
    SceneChat,
    SceneShop
}
