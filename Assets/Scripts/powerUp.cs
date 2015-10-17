using UnityEngine;
using System.Collections;

public class powerUp : Difference{
	public GameObject powerUpAffector;
    public AudioClip pickup;
    private AudioSource source;

	// Use this for initialization
	void Start () {
        source = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		// gameObject.transform.position += new Vector3 (1, 0, 0) * Time.deltaTime;
	}
	
	void OnPlayerHit(ControllerColliderHit col){
        source.PlayOneShot(pickup);
		GameObject affector = GameObject.Instantiate (powerUpAffector);
		affector.transform.parent = col.controller.gameObject.transform;
		affector.transform.localPosition = Vector3.zero;
		Destroy (gameObject);
	}
}
