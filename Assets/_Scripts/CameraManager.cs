using UnityEngine;
using System.Collections;

public class CameraManager : Difference {
	// Use this for initialization
	void Start () {
		if(isPlayer1) {
			gameObject.GetComponent<Camera>().rect = new Rect(0, 0, 0.5f, 1);
		} else {
			gameObject.GetComponent<Camera>().rect = new Rect(0.5f, 0, 0.5f, 1);
		}
	}
	
	// Update is called once per frame
	void Update () {

	}
}
