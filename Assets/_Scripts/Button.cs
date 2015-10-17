using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {
	public bool deadMan = false;
	public GameObject target;

	int pressTrack = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(deadMan && pressTrack > 0) {
			pressTrack--;
			if(pressTrack == 0) {
				Debug.Log ("Button Released");
				target.gameObject.SendMessage("ButtonReleased", this);
			}
		}
	}

	void OnPlayerHit(ControllerColliderHit coll) {
		if(pressTrack == 0) {
			pressTrack = 2;
			Debug.Log ("Button Pressed");
			target.gameObject.SendMessage("ButtonPressed", this);
		}
		pressTrack = 2;
	}
}
