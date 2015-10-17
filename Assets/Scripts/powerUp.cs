using UnityEngine;
using System.Collections;

public class powerUp : MonoBehaviour {

	// Use this for initialization
	void Start () {

	
	}
	
	// Update is called once per frame
	void Update () {
		// gameObject.transform.position += new Vector3 (1, 0, 0) * Time.deltaTime;
	}
	public Transform explosionPrefab;
	void OnCollisionEnter(Collision col){
		ContactPoint contact = col.contacts [0];
		Quaternion rot = Quaternion.FromToRotation (vector3.up, contact.normal);
		Vector3 pos = contact.point;
		Instantiate (explosionPrefab, pos, rot);
		Destroy (gameObject);
			//foreach (ContactPoint contact in col.contacts) {
			//Debug.DrawRay (contact.point, contact.normal, Color.blue);

	}
}
