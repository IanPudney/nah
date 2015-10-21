using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class IntroButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
        if (Mathf.Abs(Input.GetAxis("Start")) > .05f
		    || Input.GetKeyDown (KeyCode.Return)) {
			GameObject.Find("PressStartOrEnterShadow").GetComponent<Text>().text = "Loading...";
			GameObject.Find("PressStartOrEnter").GetComponent<Text>().text = "Loading...";
			Application.LoadLevel("Level2");
        }
	}
}
