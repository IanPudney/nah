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

	void OnCollisionEnter(Collision col){
		GameObject.Instantiate (powerUpAffector);
		powerUpAffector.transform.parent = col.gameObject.transform;
		powerUpAffector.transform.localPosition = Vector3.zero;
		Destroy (gameObject);
	}
}
