﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class VictoryCondition : MonoBehaviour {

    public Text text;
    public GameObject fireWorks;

	// Use this for initialization
    void OnPlayerHit(ControllerColliderHit coll) {
        //col.gameObject.GetComponent<Player>();
        text.text = "Victory!";
        text.gameObject.SetActive(true);
        Invoke("ReloadLevel", 10f);
    }
	
	// Update is called once per frame
	void Update () {
        if (fireWorks != null) {
            fireWorks.SetActive(true);
        }
	}

    void ReloadLevel() {
        Application.LoadLevel("IntroScene");
    }
}
