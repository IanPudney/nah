using UnityEngine;
using System.Collections;

public class IntoPlaceBlock : MonoBehaviour {
	public float moveDistance = 100;
	public float period = 4;
	public Vector3 initialPosition;
	// Use this for initialization
	void Start () {
		initialPosition = transform.localPosition;
	}
	
	// Update is called once per frame
	void Update () {
		transform.localPosition += Vector3.up * moveDistance * Time.deltaTime / period;
		Debug.Log(initialPosition.y + moveDistance);
		if(transform.localPosition.y > initialPosition.y + moveDistance) {
			Debug.Log ("destroying this");
			transform.localPosition = initialPosition + Vector3.up * moveDistance;
			Destroy (this);
		}
	}
}
