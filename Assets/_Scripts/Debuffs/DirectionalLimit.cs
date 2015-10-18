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
        if (directionalLimit == Direction.Left) {
            enemy.leftLimit = true;
            indicatorText.text = "You cannot move Left";
        }
        else if (directionalLimit == Direction.Right) {
            enemy.rightLimit = true;
            indicatorText.text = "You cannot move Right";
        }
        else if (directionalLimit == Direction.Down) {
            enemy.downLimit = true;
            indicatorText.text = "You cannot move Down";
        }
        else if (directionalLimit == Direction.Up) {
            enemy.upLimit = true;
            indicatorText.text = "You cannot move Up";
        }
        else if (directionalLimit == Direction.Jump) {
            enemy.jumpLimit = true;
            indicatorText.text = "You cannot Jump";
        }
	}

    void OnDestroy() {
        if (directionalLimit == Direction.Left) {
            enemy.leftLimit = false;
        }
        else if (directionalLimit == Direction.Right) {
            enemy.rightLimit = false;
        }
        else if (directionalLimit == Direction.Down) {
            enemy.downLimit = false;
        }
        else if (directionalLimit == Direction.Up) {
            enemy.upLimit = false;
        }
        else if (directionalLimit == Direction.Jump) {
            enemy.jumpLimit = false;
        }
        indicatorText.text = "No limits";
    }
}
