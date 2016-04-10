using UnityEngine;
using System.Collections;

public class PanelPlayInfo : PanelBase {

    protected override void OnInitSkin()
    {
        base.SetMainSkinPath("Game/UI/Home/PanelPlayInfo");
        base.OnInitSkin();
        base._type = PanelType.PanelPlayInfo;
    }

    protected override void OnInitDone()
    {
        base.OnInitDone();

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
    }
}
