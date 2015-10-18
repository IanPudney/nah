using UnityEngine;
using System.Collections;

public class CameraManager : Difference {
	public GameObject player;
	Vector3 offsetFromPlayer;
	Vector3 velocity;
	Vector3 maxVelocity;
	string rotationAxis;

	// Use this for initialization
	void Start () {
		offsetFromPlayer = transform.position - player.transform.position;
		if(isPlayer1) {
			gameObject.GetComponent<Camera>().rect = new Rect(0, 0, 0.5f, 1);
			rotationAxis = "Rotation";

		} else {
			gameObject.GetComponent<Camera>().rect = new Rect(0.5f, 0, 0.5f, 1);
			rotationAxis = "Rotation2";
		}
		velocity = Vector3.zero;
	}

	public float speed = 55.0f;
	private float rotationX = 0.0f;
	private Quaternion qTo = Quaternion.identity;
	bool rotating = false;

	// Update is called once per frame
	void Update () {
		Vector3 toMove = player.transform.position + offsetFromPlayer - transform.position;
		velocity += toMove * Time.deltaTime;
		velocity *= 0.5f;
		transform.position += velocity;

		//Handles camera rotation
		if (Input.GetAxis (rotationAxis) > 0.01) {
			if(!rotating) {
				offsetFromPlayer = Quaternion.AngleAxis(90f, Vector3.up) * offsetFromPlayer;
				player.GetComponent<Player>().RotateControls(90f);
			}
			rotating = true;
		} else if (Input.GetAxis (rotationAxis) < -0.01) {
			if(!rotating) {
				offsetFromPlayer = Quaternion.AngleAxis(-90f, Vector3.up) * offsetFromPlayer;
				player.GetComponent<Player>().RotateControls(-90f);
			}
			rotating = true;
			//rotationX -= 90.0f;
			//qTo = Quaternion.Euler (0.0f, rotationX, 0);
		} else {
			rotating = false;
		}
		transform.LookAt (player.transform); 
	}
}
