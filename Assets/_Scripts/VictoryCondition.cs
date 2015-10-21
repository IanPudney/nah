using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class VictoryCondition : MonoBehaviour {

    public Text text;
    public GameObject fireWorks;
	bool hasWon = false;

	// Use this for initialization
    void OnPlayerHit(ControllerColliderHit coll) {
        //col.gameObject.GetComponent<Player>();
        if (text != null) {
			text.text = "Victory!\n<color=#AAAAAA><size=90>Press Enter\nto leave game</size></color>";
            text.gameObject.SetActive(true);
			hasWon = true;
        }
        //Invoke("ReloadLevel", 30f);
    }
	
	// Update is called once per frame
	void Update () {
		if(hasWon) {
			if(Input.GetKeyDown (KeyCode.Return)) {
				Application.LoadLevel ("IntroScene");
			}
		}
        if (fireWorks != null) {
            fireWorks.SetActive(true);
        }
	}

    void ReloadLevel() {
        Application.LoadLevel("IntroScene");
    }
}
