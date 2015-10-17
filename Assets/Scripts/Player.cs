using UnityEngine;
using System.Collections;

public class Player : Difference {
	public float speed = 6.0F;
	public float jumpSpeed = 8.0F;
	public float gravity = 20.0F;
	public float airSpeed = 0.5F;
	private Vector3 moveDirection = Vector3.zero;
	private Vector3 previousPosition = Vector3.zero;

	string horizontalAxis;
	string verticalAxis;
	string jumpAxis;

	// Use this for initialization
	void Start () {
		if(isPlayer1) {
			horizontalAxis = "Horizontal";
			verticalAxis = "Vertical";
			jumpAxis = "Jump";
		} else {
			horizontalAxis = "Horizontal2";
			verticalAxis = "Vertical2";
			jumpAxis = "Jump2";
		}
		previousPosition = transform.position;
	}

	// Update is called once per frame
	void Update () {
		CharacterController controller = GetComponent<CharacterController>();

		moveDirection.x = (transform.position.x - previousPosition.x) / Time.deltaTime;
		moveDirection.z = (transform.position.z - previousPosition.z) / Time.deltaTime;

		if (controller.isGrounded) {
			moveDirection = new Vector3(Input.GetAxis(horizontalAxis), 0, Input.GetAxis(verticalAxis));
			moveDirection *= speed;
			if (Input.GetButton(jumpAxis))
				moveDirection.y += jumpSpeed;
		} else {
			Vector3 newMoveDirection = new Vector3(Input.GetAxis(horizontalAxis), 0, Input.GetAxis(verticalAxis));
			Debug.Log (newMoveDirection);
			newMoveDirection.y = 0;
			newMoveDirection *= airSpeed;
			moveDirection += newMoveDirection;

			if(moveDirection.x > speed)  moveDirection.x =  speed;
			if(moveDirection.x < -speed) moveDirection.x = -speed;
			if(moveDirection.z > speed)  moveDirection.z =  speed;
			if(moveDirection.z < -speed) moveDirection.z = -speed;
		}
		moveDirection.y -= gravity * Time.deltaTime;
		previousPosition = transform.position;;
		controller.Move(moveDirection * Time.deltaTime);
	}

	void OnControllerColliderHit(ControllerColliderHit hit){
		hit.gameObject.SendMessage("OnPlayerHit", hit, SendMessageOptions.DontRequireReceiver);
	}
}
