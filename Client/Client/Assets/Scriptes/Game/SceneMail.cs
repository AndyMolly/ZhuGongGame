using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class SceneMail :SceneBase {


    private GameObject mItem;
    private List<GameObject> mItemList;

    protected override void OnInitSkin()
    {
        base.SetMainSkinPath("Game/UI/SceneMail");
        base.OnInitSkin();
    }

    protected override void OnInitDone()
    {
        base.OnInitDone();

        mItem = SkinTransform.Find("PanelMove/Items/Item").gameObject;
        ShowItems();
    }


    protected override void OnClick(GameObject click)
    {
        base.OnClick(click);

        ClickButton(click);
    }

    private void ClickButton(GameObject click)
    {
        if (click.name.Equals("BtnMail"))
        {
            SceneMgr.Instance.SwitchScene(SceneType.SceneMail);
        }
        else if (click.name.Equals("BtnReturn"))
        {
            SceneMgr.Instance.SwitchToPrevScene();
        }
    }

    void ShowItems()
    {
        if (mItem == null)
        {
            Debug.Log("Item null");
            return;
        }

        mItemList = new List<GameObject>();
        for (int i = 0; i < 10; i++)
        {
            var item = Instantiate(mItem) as GameObject;
            item.transform.parent = mItem.transform.parent;
            item.SetActive(true);

            item.transform.localEulerAngles = Vector3.zero;
            item.transform.localScale = Vector3.one;
            item.name=i.ToString();
            InitItem(item, i);
        }
    }
    void InitItem(GameObject item, int index)
    {
        item.transform.localPosition = new Vector3(0, 75 - (index ) * 66, 0);
        GameObject btnDelet=item.transform.Find("BtnDelete").gameObject;
        UIEventListener listenser = UIEventListener.Get(btnDelet);
        listenser.onClick += (click) => {

            if (click.name.Equals("BtnDelete"))
            {
                Debug.Log("点击" + click.transform.parent.name);
                mItemList.Remove(click.transform.parent.gameObject);
                Destroy(click.transform.parent.gameObject);

                ChangePosition();
            }
        };
       
        UILabel title = item.transform.Find("Title").GetComponent<UILabel>();
        UILabel time = item.transform.Find("SendTime").GetComponent<UILabel>();

        title.text = "王麻子的来信" + index;
        time.text = DateTime.Now.ToString();

        mItemList.Add(item);
    }
    void ChangePosition()
    {
        for (int i = 0; i < mItemList.Count; i++)
        {
            mItemList[i].transform.localPosition = new Vector3(0, 75 - (i) * 66, 0);
        }
    }
}
