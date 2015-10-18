using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ForceJump : MonoBehaviour {
	Player enemy;
	public Text indicatorText;
	GameObject[] textHunt;
	
	// Use this for initialization
	void Start() {
		enemy = GetComponentInParent<Player>();
		textHunt = GameObject.FindGameObjectsWithTag("DebuffIndicator");
		for (int i = 0; i < textHunt.Length; i++) {
			if (textHunt[i].GetComponent<Difference>().isPlayer1 == enemy.isPlayer1) {
				indicatorText = textHunt[i].GetComponent<Text>();
			}
		}
		enemy.forceJump = true;
        for (int i = 0; i < enemy.fireParticles.Length; i++) {
            enemy.fireParticles[i].SetActive(true);
        }
	}

	void Update () {

	}

	void OnDestroy() {
		enemy.forceJump = false;
        for (int i = 0; i < enemy.fireParticles.Length; i++) {
            enemy.fireParticles[i].SetActive(false);
        }
	}
}
