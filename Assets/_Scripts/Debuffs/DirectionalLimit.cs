using UnityEngine;
using System.Collections;

public class DirectionalLimit : MonoBehaviour {
    Player enemy;
    public enum Direction { Left, Right, Down, Up, Jump}
    public Direction directionalLimit;
	// Use this for initialization
	void Start () {
        enemy = GetComponentInParent<Player>();
	}
	
	// This limit will stop the player from moving on an X or Z axis.
	void Update () {
        if (directionalLimit == Direction.Left) {
            enemy.leftLimit = true;
        }
        else if (directionalLimit == Direction.Right) {
            enemy.rightLimit = true;
        }
        else if (directionalLimit == Direction.Down) {
            enemy.downLimit = true;
        }
        else if (directionalLimit == Direction.Up) {
            enemy.upLimit = true;
        }
        else if (directionalLimit == Direction.Jump) {
            enemy.jumpLimit = true;
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
    }
}
