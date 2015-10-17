using UnityEngine;
using System.Collections;

public class CameraManager : Difference {
	public GameObject player;
	Vector3 offsetFromPlayer;
	Vector3 velocity;
	Vector3 maxVelocity;
	// Use this for initialization
	void Start () {
		offsetFromPlayer = transform.position - player.transform.position;
		if(isPlayer1) {
			gameObject.GetComponent<Camera>().rect = new Rect(0, 0, 0.5f, 1);
		} else {
			gameObject.GetComponent<Camera>().rect = new Rect(0.5f, 0, 0.5f, 1);
		}
		velocity = Vector3.zero;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 toMove = player.transform.position + offsetFromPlayer - transform.position;
		velocity += toMove * Time.deltaTime;
		velocity *= 0.5f;
		transform.position += velocity;
	}
}
