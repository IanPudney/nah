using UnityEngine;
using System.Collections;

public class LowGravity : MonoBehaviour {
	Player enemy;
	public float prev_gravity;

	// Use this for initialization
	void Start () {
		enemy = GetComponentInParent<Player>();
		prev_gravity = enemy.gravity;
		enemy.gravity = enemy.gravity / 2;
		enemy.lowGravity = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnDestroy(){
		enemy.gravity = prev_gravity;
		enemy.lowGravity = false;
	}
}
