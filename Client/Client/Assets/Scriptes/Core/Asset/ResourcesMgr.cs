using UnityEngine;
using System.Collections;

public class ResourcesMgr : MonoBehaviour
{

    #region  初始化

    private static ResourcesMgr mInstance;

    public static ResourcesMgr GetInstance()
    {
        if (mInstance == null)
        {
            mInstance = new GameObject("_ResourcesMgr").AddComponent<ResourcesMgr>();
        }
        return mInstance;
    }
    #endregion
    /// <summary> 资源缓存集合</summary>
    private Hashtable hashtable;

    private ResourcesMgr()
    {
        hashtable = new Hashtable();
    }
    /// <summary>
    /// 从Res中加载资源
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="path"></param>
    /// <param name="cache"></param>
    /// <returns></returns>

    public T Load<T>(string path, bool cache) where T : UnityEngine.Object
    {
        if (hashtable.Contains(path))
        {
            return hashtable[path] as T;
        }

        T assetObj = Resources.Load<T>(path);
        if (assetObj == null)
        {
            Debug.Log("资源不存在" + path);
        }

        if (cache)
        {
            hashtable.Add(path, assetObj);
            Debug.Log("对象缓存 path=" + path);
        }
        
        return assetObj;
    }
    /// <summary>
    /// 从Res中创建游戏对象
    /// </summary>
    /// <param name="path"></param>
    /// <param name="cache"></param>
    /// <returns></returns>

    public GameObject CreateGameObject(string path, bool cache)
    {
        GameObject assetObj = Load<GameObject>(path, cache);
        GameObject go = Instantiate(assetObj) as GameObject;
        if (go == null)
        {
            Debug.Log("从Res中创建游戏对象失败 path=" + path);
        }
        return go;
    }
}
