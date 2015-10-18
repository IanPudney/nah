using UnityEngine;
using System.Collections;
using System;

public class Button : MonoBehaviour {
	public bool deadMan = false;
	public GameObject target;
	public GameObject Emitter;
	public bool other = false;

	int pressTrack = 0;
	Vector3 startPosition;
	GameObject slider;
	GameObject emitter;
	int simulateNextFrame = 0;
	GameObject actualTarget;

	// Use this for initialization
	void Start () {
		try {
			slider = GetChild ("Slider").gameObject;
		} catch (Exception ex) {}
	}
	
	// Update is called once per frame
	void Update () {
		if(other) {
			actualTarget = this.GetOther ().target;
		} else {
			actualTarget = target;
		}
		try {
			if(simulateNextFrame == 1) {
				emitter.GetComponent<ParticleSystem>().Simulate(emitter.GetComponent<ParticleSystem>().startLifetime);
				emitter.GetComponent<ParticleSystem>().Play();
				simulateNextFrame = 0;
			} else {
				simulateNextFrame--;
			}
		} catch (Exception ex) {}
		if(deadMan && pressTrack > 0) {
			pressTrack--;
			if(pressTrack == 0) {
				Debug.Log ("Button Released");
				try {
					slider.transform.localPosition = startPosition;
				} catch (Exception ex) {}
				actualTarget.gameObject.SendMessage("ButtonReleased", this);
					if(emitter != null) Destroy (emitter);
			}
		}
	}

	void OnPlayerHit(ControllerColliderHit coll) {
		if(pressTrack == 0) {
			pressTrack = 2;
			Debug.Log ("Button Pressed");
			try {
				startPosition = slider.transform.localPosition;
				slider.transform.localPosition -= new Vector3(0, 0.1f, 0);
			} catch (Exception ex) {}

			actualTarget.gameObject.SendMessage("ButtonPressed", this);

			try {
				emitter = GameObject.Instantiate(Emitter);
				emitter.transform.parent = transform;
				emitter.transform.localPosition = Vector3.zero;
				emitter.transform.localRotation = Quaternion.identity;
				emitter.GetComponent<BeamEmitter>().target = actualTarget;
				simulateNextFrame = 5;
			} catch (Exception ex) {}
		}
		pressTrack = 2;
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
