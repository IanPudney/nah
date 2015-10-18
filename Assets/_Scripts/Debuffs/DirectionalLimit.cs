using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DirectionalLimit : MonoBehaviour {
    Player enemy;
    public enum Direction { Left, Right, Down, Up, Jump}
    public Direction directionalLimit;
    public Text indicatorText;
    GameObject[] textHunt;
    AnalogUI analogRef;

	// Use this for initialization
    void Start() {
        enemy = GetComponentInParent<Player>();
        textHunt = GameObject.FindGameObjectsWithTag("DebuffIndicator");
        for (int i = 0; i < textHunt.Length; i++) {
            if (textHunt[i].GetComponent<Difference>().isPlayer1 == enemy.isPlayer1) {
                indicatorText = textHunt[i].GetComponent<Text>();
            }
        }
        analogRef = enemy.transform.FindChild("AnalogUI").GetComponent<AnalogUI>();

        //indicatorText.text = "";
        if (directionalLimit == Direction.Left) {
            enemy.leftLimit = true;
            //indicatorText.text += "You cannot move Left\n";
            analogRef.set_renderer(AnalogUI.Directions.Left, true);
        }
        if (directionalLimit == Direction.Right) {
            enemy.rightLimit = true;
            //indicatorText.text = "You cannot move Right\n";
            analogRef.set_renderer(AnalogUI.Directions.Right, true);
        }
        if (directionalLimit == Direction.Down) {
            enemy.downLimit = true;
            //indicatorText.text = "You cannot move Down\n";
            analogRef.set_renderer(AnalogUI.Directions.Down, true);
        }
        if (directionalLimit == Direction.Up) {
            enemy.upLimit = true;
            //indicatorText.text = "You cannot move Up\n";
            analogRef.set_renderer(AnalogUI.Directions.Up, true);
        }
    }
	
	// This limit will stop the player from moving on an X or Z axis.
	void Update () {
		
	}

    void OnDestroy() {
        if (directionalLimit == Direction.Left) {
            enemy.leftLimit = false;
            analogRef.set_renderer(AnalogUI.Directions.Left, false);
        }
        if (directionalLimit == Direction.Right) {
            enemy.rightLimit = false;
            analogRef.set_renderer(AnalogUI.Directions.Right, false);
        }
        if (directionalLimit == Direction.Down) {
            enemy.downLimit = false;
            analogRef.set_renderer(AnalogUI.Directions.Down, false);
        }
        if (directionalLimit == Direction.Up) {
            enemy.upLimit = false;
            analogRef.set_renderer(AnalogUI.Directions.Up, false);
        }
        if (directionalLimit == Direction.Jump) {
            enemy.jumpLimit = false;
        }
        //indicatorText.text = "No limits";
    }
}
