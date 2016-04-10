using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SceneShop : SceneBase
{
    private List<GameObject> menuButtons = new List<GameObject>();
    private GameObject mItem;
    /// <summary>
    /// 所有商品数据
    /// </summary>
    List<ShopItemData> mData = new List<ShopItemData>();
    /// <summary>
    /// 一行元素个数
    /// </summary>
    private int moneLineNum = 3;
    /// <summary>
    /// 行数
    /// </summary>
    private int mline = 0;
    /// <summary>
    /// 行余数
    /// </summary>
    private int mRemainder = 0;
    protected override void OnInitSkin()
    {
        base.SetMainSkinPath("Game/UI/SceneShop");
        base.OnInitSkin();
    }

    protected override void OnInitDone()
    {
        base.OnInitDone();
        Init();
    }
    private void Init()
    {
        mItem = SkinTransform.Find("PanelMove/Items/Item").gameObject;

        Transform menuTran = SkinTransform.Find("Conten/Menu");
        BoxCollider[] buttonArr = menuTran.GetComponentsInChildren<BoxCollider>(true);
        foreach (var box in buttonArr)
        {
            menuButtons.Add(box.gameObject);
        }
        mData = MoNiData(Random.Range(10,30));
        ShowItems();
    }
    void ShowItems()
    {
        mline = mData.Count / moneLineNum;
        mRemainder = mData.Count % moneLineNum;
        if (mRemainder != 0)
        {
            mline++;
        }

        for (int i = 0; i < mline; i++)
        {
            GameObject item = Instantiate(mItem) as GameObject;
            item.transform.parent = mItem.transform.parent;
            item.transform.localEulerAngles = Vector3.zero;
            item.transform.localScale = Vector3.one;
            item.transform.localPosition =new Vector3(0, 65-270*i, 0);
            item.SetActive(true);
            item.name = i.ToString();
            InitItem(item,i);

        }
    }

    void InitItem(GameObject item,int index)
    {
        SelfShopItem self = item.GetComponent<SelfShopItem>();
        foreach (GameObject obj in self.selfList)
        {
            UIEventListener listener = UIEventListener.Get(obj);
            //UIEventListener lisParent = UIEventListener.Get(item.transform.parent.parent.gameObject);
            //lisParent.onDrag = listener.onDrag(obj, Vector2.one);
            listener.onClick += (e) =>
                {
                    ItemClick(e);
                    return;
                };
        }
        List<ShopItemData> list = new List<ShopItemData>();
        int nowListIndex = index * moneLineNum;
        int forNum = moneLineNum;
        if (index == mline - 1 && mRemainder != moneLineNum)
        {
            forNum = mRemainder;
        }
        for (int i = 0; i < forNum; i++)
        {
            ShopItemData data = mData[nowListIndex + i];
            list.Add(data);
        }
        self.Init(list);
    }

    private void ItemClick(GameObject e)
    {
        if (e.name.StartsWith("Shop_"))
        {
            int id = 0;
            if (!int.TryParse(e.name.Replace("Shop_", ""), out id)) return;
            PanelMgr.Instance.ShowPanel(PanelType.PanelShop, id);
        }
    }
    List<ShopItemData> MoNiData(int nums)
    {
        List<ShopItemData> list = new List<ShopItemData>();
        for (int i = 0; i < nums; i++)
        {
            ShopItemData data = new ShopItemData();
            data.id = Random.Range(100, 199);
            if (data.id >= 100 && data.id < 120)
            {
                data.type = 0;
            }
            if (data.id >= 120 && data.id < 140)
            {
                data.type = 1;
            }
            if (data.id >= 140 && data.id < 160)
            {
                data.type = 2;
            }
            if (data.id >= 160 && data.id < 180)
            {
                data.type = 3;
            }
            if (data.id >= 180 && data.id < 200)
            {
                data.type = 4;
            }
            data.num = Random.Range(1, 99);
            data.name = "商品"+data.id.ToString();
            data.pic = Random.Range(100,999);
            list.Add(data);
        }
        return list;
    }

    public override void OnResetArgs(params object[] sceneArgs)
    {
        base.OnResetArgs(sceneArgs);
    }

    protected override void OnClick(GameObject click)
    {
        base.OnClick(click);

        ClickButton(click);
    }

    private void ClickButton(GameObject click)
    {
        if (click.name.Equals("BtnClose"))
        {
            SceneMgr.Instance.SwitchScene(SceneType.SceneHome);
        }
        else if (click.name.Equals("BtnReturn"))
        {
            SceneMgr.Instance.SwitchToPrevScene();
        }
        else if (click.name.Equals("BtnProp"))
        {
            ChangeMenuButtonStyle(click);
        }
        else if (click.name.Equals("BtnMateria"))
        {
            ChangeMenuButtonStyle(click);
        }
        else if (click.name.Equals("BtnPackage"))
        {
            ChangeMenuButtonStyle(click);
        }
    }

    private void ChangeMenuButtonStyle(GameObject clickButton)
    {
        foreach (GameObject obj in menuButtons)
        {
            UISprite sprite = obj.GetComponent<UISprite>();
            UILabel label = obj.transform.Find("Label").GetComponent<UILabel>();
            if (obj.Equals(clickButton))
            {
                sprite.color = Color.white;
            }
            else
            {
                sprite.color = new Color(205.0f / 255.0f, 205.0f / 255.0f, 205.0f / 255.0f);
            }
        }
    }
}
