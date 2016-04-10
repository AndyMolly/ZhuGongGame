using UnityEngine;
using System.Collections;

public class SceneHome : SceneBase {
    private UIInput mInputAcc;
    private UIInput mInputPass;

    protected override void OnInitSkin()
    {
        base.SetMainSkinPath("Game/UI/Home/SceneHome");
        base.OnInitSkin();
    }

    protected override void OnInitDone()
    {
        base.OnInitDone();

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
        if (click.name.Equals("BtnMail"))
        {
            SceneMgr.Instance.SwitchScene(SceneType.SceneMail);
        }else if(click.name.Equals("BtnHeadIcon"))
        {
            PanelMgr.Instance.ShowPanel(PanelType.PanelPlayInfo);
        }
        else if (click.name.Equals("Recharge"))
        {
            SceneMgr.Instance.SwitchScene(SceneType.SceneShop);
        }
    }

}
