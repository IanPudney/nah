using UnityEngine;
using System.Collections;

public class BeamEmitter : MonoBehaviour {
	public GameObject target;
	// Use this for initialization
	float targetDistance;

	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		targetDistance = (target.transform.position - transform.position).magnitude;
		transform.LookAt (target.transform);
		ParticleSystem system = GetComponent<ParticleSystem>();
		system.startLifetime = targetDistance / system.startSpeed;
	}
}
