using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SelfShopItem : MonoBehaviour {

    public List<GameObject> selfList = new List<GameObject>();

    /// <summary>
    /// 初始化
    /// </summary>
    public void Init(List<ShopItemData> list)
    {
       // Debug.Log("初始化" + gameObject.name);
        for (int i = 0; i < list.Count; i++)
        {
            GameObject item = selfList[i];
            ShopItemData data = list[i];
            UILabel name = item.transform.Find("Name").GetComponent<UILabel>();
            UISprite pinzhi = item.transform.Find("Pinzhi").GetComponent<UISprite>();
            UISprite icon = item.transform.Find("Pinzhi/Icon").GetComponent<UISprite>();
            UILabel num = item.transform.Find("Pinzhi/Num").GetComponent<UILabel>();
            UISprite activityIcon = item.transform.Find("ActivetyIcon").GetComponent<UISprite>();
            UILabel pic = item.transform.Find("Price").GetComponent<UILabel>();
            name.text = data.name;
            num.text = data.num.ToString();
            pic.text = data.pic.ToString();
            item.name = "Shop_" + data.id.ToString();
        }
        if (list.Count < selfList.Count)
        {
            int num = selfList.Count - list.Count;
            for (int i = selfList.Count - 1; i >= selfList.Count - num; i--)
            {
                GameObject item = selfList[i];
                item.SetActive(false);
            }
        }
    }
}
public class ShopItemData
{
    /// <summary>
    /// 名称
    /// </summary>
    public string name;
    /// <summary>
    /// 数量
    /// </summary>
    public int num;
    /// <summary>
    /// id
    /// </summary>
    public int id;
    /// <summary>
    /// 类型
    /// </summary>
    public int type;
    public int pic;
}
