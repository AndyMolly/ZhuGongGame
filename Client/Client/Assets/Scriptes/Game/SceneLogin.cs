using UnityEngine;
using System.Collections;

public class SceneLogin : SceneBase {

    private UIInput mInputAcc;
    private UIInput mInputPass;

    protected override void OnInitSkin()
    {
        base.SetMainSkinPath("Game/UI/SceneLogin");
        base.OnInitSkin();
    }

    protected override void OnInitDone()
    {
        base.OnInitDone();

        mInputAcc = SkinTransform.Find("InputAce").GetComponent<UIInput>();
        mInputPass = SkinTransform.Find("InputPass").GetComponent<UIInput>();

        string str = (string)_sceneArgs[0];
        Debug.Log(str+"sdfs afdsafsdafafdsaf");
        int i = (int)_sceneArgs[1];
        bool bo = (bool)_sceneArgs[2];

        Debug.Log(str + "----" + i + " ----" + bo);
    }

    // Use this for initialization
    //void Start()
    //{
    //    base.Init();

    //    mInputAcc = this.transform.Find("InputAce").GetComponent<UIInput>();
    //    mInputPass = this.transform.Find("InputPass").GetComponent<UIInput>();

    //    //BoxCollider[] boxs = transform.GetComponentsInChildren<BoxCollider>(true);
    //    //foreach (BoxCollider box in boxs)
    //    //{
    //    //    UIEventListener lisenter = UIEventListener.Get(box.gameObject);
    //    //    lisenter.onClick += (click) =>
    //    //    {
    //    //        if (click.name.Equals("BtnLogin"))
    //    //        {
    //    //            Debug.Log(string.Format("点击了登录 账号{0}  密码 {1}", mInputAcc.value, mInputPass.value));

    //    //           // ResourcesMgr.GetInstance().CreateGameObject("Game/UI/SceneLoading", false);
    //    //           // Destroy(this.gameObject);

    //    //            SceneMgr.Instance.SwitchScene("SceneLoading");
    //    //        }
    //    //        else if (click.name.Equals("BtnReg"))
    //    //        {

    //    //        }
    //    //    };
    //    //}
    //}
    private void ClickButton(GameObject click)
    {
        if (click.name.Equals("BtnLogin"))
        {
            Debug.Log(string.Format("点击了登录 账号{0}  密码 {1}", mInputAcc.value, mInputPass.value));

            // ResourcesMgr.GetInstance().CreateGameObject("Game/UI/SceneLoading", false);
            // Destroy(this.gameObject);
            NetWriter.SetUrl("127.0.0.1:9001");
            Net.Instance.Send(100, LoginReturn, null);

            //SceneMgr.Instance.SwitchScene(SceneType.SceneLoading, "hello");
        }
        else if (click.name.Equals("BtnReg"))
        {

        }
    }
    private bool isLogin = false;
    void LoginReturn(ActionResult action)
    {
        Debug.Log(action["content"]);
        isLogin = (action["content"] as string).Equals("hello world");
        Debug.LogError(isLogin);

        if(isLogin)
        SceneMgr.Instance.SwitchScene(SceneType.SceneLoading, "hello");
    }
    protected override void OnClick(GameObject click)
    {
        base.OnClick(click);

        ClickButton(click);
    }
    protected override void OnDestroyFront()
    {
        base.OnDestroyFront();
        Debug.Log("OnDestroyFront");
    }
    protected override void OnDestroyEnd()
    {
        base.OnDestroyEnd();
        Debug.Log("OnDestroyEnd");
    }

}
