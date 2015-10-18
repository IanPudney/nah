using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {
	public bool deadMan = false;
	public GameObject target;
	public GameObject Emitter;

	int pressTrack = 0;
	Vector3 startPosition;
	GameObject slider;
	GameObject emitter;

	// Use this for initialization
	void Start () {
		slider = GetChild ("Slider").gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		if(deadMan && pressTrack > 0) {
			pressTrack--;
			if(pressTrack == 0) {
				Debug.Log ("Button Released");
				slider.transform.localPosition = startPosition;
				target.gameObject.SendMessage("ButtonReleased", this);
				if(emitter != null) Destroy (emitter);
			}
		}
	}

	void OnPlayerHit(ControllerColliderHit coll) {
		if(pressTrack == 0) {
			pressTrack = 2;
			Debug.Log ("Button Pressed");
			startPosition = slider.transform.localPosition;
			slider.transform.localPosition -= new Vector3(0, 0.1f, 0);
			target.gameObject.SendMessage("ButtonPressed", this);
			emitter = GameObject.Instantiate(Emitter);
			emitter.transform.parent = transform;
			emitter.transform.localPosition = Vector3.zero;
			emitter.transform.localRotation = Quaternion.identity;
			emitter.GetComponent<BeamEmitter>().target = target;
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
