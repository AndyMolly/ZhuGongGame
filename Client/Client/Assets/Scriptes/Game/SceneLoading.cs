using UnityEngine;
using System.Collections;

public class SceneLoading :SceneBase
{

    private UISlider mSlider;
    private UILabel mLabel;

    protected override void OnInitSkin()
    {
        base.SetMainSkinPath("Game/UI/SceneLoading");
        base.OnInitSkin();
    }

    protected override void OnInitDone()
    {
        base.OnInitDone();


        string str = (string)_sceneArgs[0];
        Debug.Log(str + "----");


        mSlider = SkinTransform.Find("Slider").GetComponent<UISlider>();
        mLabel = SkinTransform.Find("ProLabel").GetComponent<UILabel>();

        mSlider.value = 0;

        SetLabelInfo(mSlider.value);

        StartCoroutine(Test());
    }

    IEnumerator Test()
    {
        yield return 1;
        yield return new WaitForSeconds(0.1f);

        mSlider.value += 0.01f;
        SetLabelInfo(mSlider.value);

        if (mSlider.value < 1) 
        {
            StartCoroutine(Test());
        }
        else
        {
            Debug.Log("加载完成");
            SceneMgr.Instance.SwitchScene(SceneType.SceneHome,"hha",44,false);
        }
    }
    void SetLabelInfo(float value)
    {
        if (mLabel != null)
        {
            mLabel.text = (mSlider.value * 100.0f).ToString("f2") + "%";
        }
    }
}
