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
	private Vector3 doublePreviousPosition = Vector3.zero;
    private Vector3 previousGroundedPosition = Vector3.zero;
	private Vector3 previousInput = Vector3.zero;
	private int jumpFrame = 0;

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

    Quaternion controlRotation = Quaternion.identity;

    /* LIMITS */
    public bool leftLimit, rightLimit, upLimit, downLimit, jumpLimit = false;
    public bool forceJump, weakJump = false;
    public bool speedUp = false;
	public bool lowGravity = false;
    public bool cameraLimit = false;

    /* PARTICLES */
    public GameObject[] fireParticles;

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
		doublePreviousPosition = transform.position;
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
		audioSources[0].volume = 0.2f;
		audioSources[1].volume = 0f;
	}

	// Update is called once per frame
	void Update () {
        //var inputDevice = InputManager.ActiveDevice;
		CharacterController controller = GetComponent<CharacterController>();
		float cacheY = moveDirection.y;
		Vector3 input = new Vector3(Input.GetAxis(horizontalAxis) , 0, Input.GetAxis(verticalAxis));

/*		if(leftLimit) input.x = Mathf.Max(input.x, 0);
		if(rightLimit) input.x = Mathf.Min(input.x, 0);
		if(upLimit) input.z = Mathf.Max(input.z, 0);
		if(downLimit) input.z = Mathf.Min(input.z, 0);
*/		if (lowGravity && !controller.isGrounded) {
			input = previousInput;
			//input.x = (doublePreviousPosition - transform.position).x /2;
			//input.z = (doublePreviousPosition - transform.position).z /2;

		} else {
			previousInput = input;
		}

		if(leftLimit && input.x < 0) input.x = 0;
		if(rightLimit && input.x > 0) input.x = 0;
		if(downLimit && input.z < 0) input.z = 0;
		if(upLimit && input.z > 0) input.z = 0;
		moveDirection = controlRotation * input;
		moveDirection *= speed;
		moveDirection.y = cacheY;
		
		if (controller.isGrounded) {
			moveDirection.y = 0;
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
            if (jumpFrame == 0 && (forceJump || Input.GetButton(jumpAxis))) {
                if (!jumpLimit) {
                    jumpFrame = 5;
                    audioSources[1].Play();
                    moveDirection.y += jumpSpeed;
                }
            }
			jumpFrame-= 1;
			if(jumpFrame < 0) {
				jumpFrame = 0;
			}
		}
		moveDirection.y -= gravity * Time.deltaTime;
		if((doublePreviousPosition - transform.position).magnitude > 0.01f) {
			Quaternion newRotation = Quaternion.LookRotation(doublePreviousPosition - transform.position);
			//clamp the rotation to a maximum angle
			transform.rotation = Quaternion.RotateTowards(transform.rotation, newRotation, 720f * Time.deltaTime);
		}
		if(legPosition > 1f) {
			legDirection = false;
		} else if(legPosition < -1f){
			legDirection = true;
		}
		if(legDirection) {
			legPosition += (doublePreviousPosition - transform.position).magnitude * legSpeed * speed;
			leftLeg.transform.localRotation = Quaternion.Euler (legAngle * -legPosition, 0, 0);
			rightLeg.transform.localRotation = Quaternion.Euler (legAngle * legPosition, 0, 0);
		} else {
			legPosition -= (doublePreviousPosition - transform.position).magnitude * legSpeed;
			leftLeg.transform.localRotation = Quaternion.Euler (legAngle * -legPosition, 0, 0);
			rightLeg.transform.localRotation = Quaternion.Euler (legAngle * legPosition, 0, 0);
		}
		doublePreviousPosition = previousPosition;
		previousPosition = transform.position;

		//apply limits
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
		foreach (Transform child in from.transform){
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

    public void RotateControls(float angle) {
        controlRotation *= Quaternion.AngleAxis(angle, Vector3.up);
    }
}
