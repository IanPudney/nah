using UnityEngine;
using System.Collections;

public class Player : Difference {
	public float speed = 3.0F;
	public float jumpSpeed = 8.0F;
	public float gravity = 20.0F;
	public float airSpeed = 0.5F;
	public float legSpeed = 6F;
	float legAngle = 40f;
	private Vector3 moveDirection = Vector3.zero;
	private Vector3 previousPosition = Vector3.zero;
    private Vector3 previousGroundedPosition = Vector3.zero;

	string horizontalAxis;
	string verticalAxis;
	string jumpAxis;

	GameObject model;
	GameObject leftLeg;
	GameObject rightLeg;

	float legPosition = 0;
	bool legDirection = true;

    public AudioClip[] audioClips;
    private AudioSource[] audioSources;
    bool stepPlayed = false;

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
		model = GetChild ("PlayerModel").gameObject;
		leftLeg = GetChild (model, "LeftLeg").gameObject;
		rightLeg = GetChild (model, "RightLeg").gameObject;
        //Setting up sounds
        //0 = Run, 1 = Jump
        audioSources = new AudioSource[audioClips.Length];
        for (int i = 0; i < audioClips.Length; i++) {
            audioSources[i] = this.gameObject.AddComponent<AudioSource>();
            audioSources[i].clip = audioClips[i];
        }
	}

	// Update is called once per frame
	void Update () {
		CharacterController controller = GetComponent<CharacterController>();

		moveDirection.x = (transform.position.x - previousPosition.x) / Time.deltaTime;
		moveDirection.z = (transform.position.z - previousPosition.z) / Time.deltaTime;

		if (controller.isGrounded) {
			moveDirection = new Vector3(Input.GetAxis(horizontalAxis), 0, Input.GetAxis(verticalAxis));
            moveDirection *= speed;
            //Only play run sound when input is down
            if (Input.GetAxis(horizontalAxis) > 0 || Input.GetAxis(verticalAxis) > 0) {
                if (!stepPlayed && legDirection == false) {
                    audioSources[0].Play();
                    stepPlayed = true;
                } 
                else if (legDirection == true)
                    stepPlayed = false;
            }
            previousGroundedPosition = transform.position;
            if (Input.GetButton(jumpAxis)) {
                audioSources[1].Play();
                moveDirection.y += jumpSpeed;
            }
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
		if((previousPosition - transform.position).magnitude > 0.01f) {
			Quaternion newRotation = Quaternion.LookRotation(previousPosition - transform.position);
			//clamp the rotation to a maximum angle
			transform.rotation = Quaternion.RotateTowards(transform.rotation, newRotation, 720f * Time.deltaTime);
		}
		if(legPosition > 1f) {
			legDirection = false;
		} else if(legPosition < -1f){
			legDirection = true;
		}
		if(legDirection) {
			legPosition += (previousPosition - transform.position).magnitude * legSpeed * speed;
			leftLeg.transform.localRotation = Quaternion.Euler (legAngle * -legPosition, 0, 0);
			rightLeg.transform.localRotation = Quaternion.Euler (legAngle * legPosition, 0, 0);
		} else {
			legPosition -= (previousPosition - transform.position).magnitude * legSpeed;
			leftLeg.transform.localRotation = Quaternion.Euler (legAngle * -legPosition, 0, 0);
			rightLeg.transform.localRotation = Quaternion.Euler (legAngle * legPosition, 0, 0);
		}

		previousPosition = transform.position;
		controller.Move(moveDirection * Time.deltaTime);

	}

	void OnControllerColliderHit(ControllerColliderHit hit){
		hit.gameObject.SendMessage("OnPlayerHit", hit, SendMessageOptions.DontRequireReceiver);
	}

	Transform GetChild(string name) {
		foreach (Transform child in transform){
			if (child.name == name){
				return child;
			}
		}
		return null;
	}

	Transform GetChild(GameObject from, string name) {
		Debug.Log (from);
		foreach (Transform child in from.transform){
			Debug.Log (child);
			if (child.name == name){
				return child;
			}
		}
		return null;
	}

    public void FallingDeath()
    {
        transform.position = previousGroundedPosition;
    }
}
