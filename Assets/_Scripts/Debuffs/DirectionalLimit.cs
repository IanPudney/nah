using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DirectionalLimit : MonoBehaviour {
    Player enemy;
    public enum Direction { Left, Right, Down, Up, Jump}
    public Direction directionalLimit;
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
    }
	
	// This limit will stop the player from moving on an X or Z axis.
	void Update () {
		indicatorText.text = "";
        if (directionalLimit == Direction.Left) {
            enemy.leftLimit = true;
            indicatorText.text += "You cannot move Left\n";
        }
        if (directionalLimit == Direction.Right) {
            enemy.rightLimit = true;
            indicatorText.text = "You cannot move Right\n";
        }
        if (directionalLimit == Direction.Down) {
            enemy.downLimit = true;
            indicatorText.text = "You cannot move Down\n";
        }
        if (directionalLimit == Direction.Up) {
            enemy.upLimit = true;
            indicatorText.text = "You cannot move Up\n";
        }
	}

    void OnDestroy() {
        if (directionalLimit == Direction.Left) {
            enemy.leftLimit = false;
        }
        if (directionalLimit == Direction.Right) {
            enemy.rightLimit = false;
        }
        if (directionalLimit == Direction.Down) {
            enemy.downLimit = false;
        }
        if (directionalLimit == Direction.Up) {
            enemy.upLimit = false;
        }
        if (directionalLimit == Direction.Jump) {
            enemy.jumpLimit = false;
        }
        indicatorText.text = "No limits";
    }
}
