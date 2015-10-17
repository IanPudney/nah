using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {
	public bool deadMan = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnPlayerHit(ControllerColliderHit coll) {
		Debug.Log (coll.gameObject);
	}
}
