using UnityEngine;
using System.Collections;

public class AnalogUI : Difference {

    Player playerParent;

	// Use this for initialization
	void Start () {
        Player[] players = GameObject.FindObjectsOfType<Player>();
        foreach (Player player in players) {
            if (player.isPlayer1 == isPlayer1) {
                playerParent = player;
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.position = playerParent.gameObject.transform.position;
	}
}
