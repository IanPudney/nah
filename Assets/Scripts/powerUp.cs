using UnityEngine;
using System.Collections;

public class powerUp : Difference{
	public GameObject powerUpAffector;

	// Use this for initialization
	void Start () {

	
	}
	
	// Update is called once per frame
	void Update () {
		// gameObject.transform.position += new Vector3 (1, 0, 0) * Time.deltaTime;
	}
	
	void OnPlayerHit(ControllerColliderHit col){
		GameObject affector = GameObject.Instantiate (powerUpAffector);
		affector.transform.parent = col.controller.gameObject.transform;
		affector.transform.localPosition = Vector3.zero;
		Destroy (gameObject);
	}
}
