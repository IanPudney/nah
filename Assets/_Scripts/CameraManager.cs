using UnityEngine;
using System.Collections;

public class CameraManager : Difference {
	public GameObject player;
	Vector3 offsetFromPlayer;
	Vector3 velocity;
	Vector3 maxVelocity;
	string rotationAxis;
	string panAxis;

	// Use this for initialization
	void Start () {
		offsetFromPlayer = transform.position - player.transform.position;
		if(isPlayer1) {
			gameObject.GetComponent<Camera>().rect = new Rect(0, 0, 0.5f, 1);
			panAxis = "Pan";
			//rotationAxis = "Rotation";

		} else {
			gameObject.GetComponent<Camera>().rect = new Rect(0.5f, 0, 0.5f, 1);
			panAxis = "Pan2";
			//rotationAxis = "Rotation2";
		}
		velocity = Vector3.zero;
	}

	public float speed = 55.0f;
	private float rotationX = 0.0f;
	private Quaternion qTo = Quaternion.identity;
	bool rotating = false;

	// Update is called once per frame
	void Update () {
        //var inputDevice = InputManager.ActiveDevice;
		/*Vector3 toMove = player.transform.position + offsetFromPlayer - transform.position;
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
		float oldRotation = transform.eulerAngles.y;
		transform.LookAt (player.transform); 
		Debug.Log ("Rotating controls by " + (transform.rotation.y - oldRotation).ToString());
		player.GetComponent<Player>().RotateControls(transform.rotation.y - oldRotation);*/
		float rotDeg = Input.GetAxis(panAxis) * 120 * Time.deltaTime;
        if (player.GetComponent<Player>().cameraLimit) rotDeg /= 3;
        Quaternion stickRotation = Quaternion.Euler (0, rotDeg, 0);
		offsetFromPlayer = stickRotation * offsetFromPlayer;
		transform.position = player.transform.position + offsetFromPlayer;
		transform.LookAt (player.transform);
		player.GetComponent<Player>().RotateControls(rotDeg);
	}
}
