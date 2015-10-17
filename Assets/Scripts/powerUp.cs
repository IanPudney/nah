using UnityEngine;
using System.Collections;

public class powerUp : Difference{
	public GameObject powerUpAffector;
    public AudioClip clip;
    public GameObject tempSoundObject;

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
		// gameObject.transform.position += new Vector3 (1, 0, 0) * Time.deltaTime;
	}
	
	void OnPlayerHit(ControllerColliderHit col){
        GameObject tempSound = Instantiate(tempSoundObject);
        AudioSource temp = tempSound.AddComponent<AudioSource>();
        temp.clip = clip;
        temp.Play();

        GameObject affector = GameObject.Instantiate (powerUpAffector);
		affector.transform.parent = col.controller.gameObject.transform;
		affector.transform.localPosition = Vector3.zero;
		Destroy (this.gameObject);
	}
}
