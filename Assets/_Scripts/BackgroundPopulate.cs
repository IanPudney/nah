using UnityEngine;
using System.Collections;

public class BackgroundPopulate : MonoBehaviour {
	public GameObject BackgroundCube;
	public float radius;
	public float radiusDelta;
	public int count;
	// Use this for initialization
	void Start () {
		for(int i = 0; i < count; ++i) {
			GameObject backgroundCube = GameObject.Instantiate(BackgroundCube);
			backgroundCube.transform.parent = transform;
			Vector3 target = Random.onUnitSphere * (radius + Random.Range(-radiusDelta, radiusDelta));
			backgroundCube.transform.localPosition = target;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
