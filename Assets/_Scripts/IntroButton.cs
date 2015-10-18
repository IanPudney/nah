using UnityEngine;
using System.Collections;

public class IntroButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    public void LoadMain() {
        Application.LoadLevel("MainScene");
    }

	// Update is called once per frame
	void Update () {
        if (Mathf.Abs(Input.GetAxis("Start")) > .05f) {
            Application.LoadLevel("MainScene");
        }
	}
}
