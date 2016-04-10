using UnityEngine;
using System.Collections;

public class PanelShop : PanelBase {

    private int mNowSeleNums = 1;
    protected override void OnInitSkin()
    {
        base.SetMainSkinPath("Game/UI/PanelShop");
        base.OnInitSkin();
        base._type = PanelType.PanelShop;
    }

    protected override void OnInitDone()
    {
        base.OnInitDone();
        int id = (int)_sceneArgs[0];
        init();
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
            this.Close();
        }
        else if (click.name.Equals("BtnShop"))
        {
            Debug.Log("发送购买消息");
            //this.Close();
        }
        else if (click.name.Equals("BtnAdd"))
        {
            if (mNowSeleNums <= 99)
            {
                mNowSeleNums++;
            }
            mInput.value = mNowSeleNums.ToString();
        }
        else if (click.name.Equals("BtnSub"))
        {
            if (mNowSeleNums > 1)
            {
                mNowSeleNums--;
            }
            mInput.value = mNowSeleNums.ToString();
        }
    }
    private UILabel mName;
   // private UILabel mInputNum;
    private UIInput mInput;

    void init()
    {
        mName = SkinTransform.Find("Name").GetComponent<UILabel>();
       // mInputNum = SkinTransform.Find("InputNum/Label").GetComponent<UILabel>();
        mInput = SkinTransform.Find("InputNum").GetComponent<UIInput>();
        mInput.value = mNowSeleNums.ToString();
        mInput.onChange.Add(new EventDelegate(ChangeInput));
    }
    void ChangeInput()
    {
        int.TryParse(mInput.value, out mNowSeleNums);
    }
}
