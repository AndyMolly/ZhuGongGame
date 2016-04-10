using UnityEngine;
using System.Collections;

public class TestGame : MonoBehaviour {

	// Use this for initialization
	void Start () {

        SceneMgr.Instance.SwitchScene(SceneType.SceneLogin,"haha",234,false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
