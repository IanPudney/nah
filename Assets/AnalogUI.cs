using UnityEngine;
using System.Collections;

public class AnalogUI : Difference {

    public Camera camera;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		transform.LookAt(camera.transform.position);
		transform.rotation = Quaternion.Euler (0, transform.rotation.eulerAngles.y, 0);
	}
}
