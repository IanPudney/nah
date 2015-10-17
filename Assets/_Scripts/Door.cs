using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {
	public float openPosition = 90f;
	public float openPeriod = 0.25f;
	public bool open = false;
	public Transform rotator;

	// Use this for initialization
	void Start () {
		rotator = GetChild ("DoorRotator");
	}
	
	// Update is called once per frame
	void Update () {
		Quaternion from;
		Quaternion to;
		if(open) {
			from = rotator.rotation;
			to = Quaternion.identity;
		} else {
			from = rotator.rotation;
			to = Quaternion.AngleAxis (openPosition, Vector3.up); //TODO: make Vector3.up be this object's relative up
		}
		rotator.rotation = Quaternion.RotateTowards(from, to, openPosition * Time.deltaTime / openPeriod);
	}

	void ButtonPressed(Button unused) {
		Debug.Log ("Received button press");
		open = true;
		//rotator.localRotation = Quaternion.Euler (0, openPosition, 0);
	}

	void ButtonReleased(Button unused) {
		open = false;
		//rotator.localRotation = Quaternion.Euler (0, 0, 0);
	}

	Transform GetChild(string name) {
		foreach (Transform child in transform){
			if (child.name == name){
				return child;
			}
		}
		return null;
	}
}
