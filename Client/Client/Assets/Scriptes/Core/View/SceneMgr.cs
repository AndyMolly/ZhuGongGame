using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class SceneMgr
{

    #region  初始化 
    protected static SceneMgr mInstance;
    public static SceneMgr Instance
    {
        get
        {
            if (mInstance == null)
            {
                mInstance = new SceneMgr();
            }
            return mInstance;
        }
    }
    private SceneMgr()
    {
        switchRecorder = new List<SwitchRecorder>();
    }
    public void OnDestory()
    {
        switchRecorder.Clear();
        switchRecorder = null;
    }
    #endregion

    private GameObject current;
    private Transform parentObj = null;
    private List<SwitchRecorder> switchRecorder;
    private string mainSceneName="SceneHome";
    public void SwitchScene(SceneType sceneType, params object[] sceneArgs)
    {
         //var scene= ResourcesMgr.GetInstance().CreateGameObject("Game/UI/"+name, false);
        string name = sceneType.ToString();
        GameObject scene = new GameObject(name);
         SceneBase baseObj= scene.AddComponent(Type.GetType(name)) as SceneBase;

        // baseObj.Init(sceneArgs);
         baseObj.OnInit(sceneArgs);

         if (parentObj == null)
         {
             parentObj = GameObject.Find("UI Root").transform;
         }
         scene.transform.parent = parentObj;
         scene.transform.localEulerAngles = Vector3.zero;
         scene.transform.localScale = Vector3.one;
         scene.transform.localPosition = Vector3.zero;
         LayerMgr.GetInstance().SetLayer(baseObj.gameObject, LayerType.Scene);

         if (name.Equals(mainSceneName))  //如果进入主场景则清空记录
         {
             switchRecorder.Clear();
         }
         switchRecorder.Add(new SwitchRecorder(sceneType, sceneArgs));
         if (current != null)
         {
             GameObject.Destroy(current);
         }
         current = scene;
    }
    /// <summary>
    /// 切换到上一个场景
    /// </summary>
    public void SwitchToPrevScene()
    {
        SwitchRecorder sr = switchRecorder[switchRecorder.Count - 2];
        switchRecorder.RemoveRange(switchRecorder.Count - 2, 2);
        SwitchScene(sr.sceneName,sr.sceneArgs);
    }
    internal struct SwitchRecorder
    {
        internal SceneType sceneName;
        internal object[] sceneArgs;
        internal SwitchRecorder(SceneType name, params object[] sceneArgs)
        {
            this.sceneName = name;
            this.sceneArgs = sceneArgs;
        }
    }
}
