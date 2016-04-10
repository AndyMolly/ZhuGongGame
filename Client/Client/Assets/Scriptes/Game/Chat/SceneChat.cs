using UnityEngine;
using System.Collections;

public class SceneChat : SceneBase {
    private UIInput mInputAcc;
    private UIInput mInputPass;

    protected override void OnInitSkin()
    {
        base.SetMainSkinPath("Game/UI/Chat/SceneChat");
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
        if (click.name.Equals("BtnReturn"))
        {
            SceneMgr.Instance.SwitchToPrevScene();
        }
    }

}
