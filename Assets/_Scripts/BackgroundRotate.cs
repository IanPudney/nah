using UnityEngine;
using System.Collections;

public class BackgroundRotate : MonoBehaviour {
	public float period = 5f;
	public float periodDelta = 1f;
	float actualPeriod;
	Vector3 rotationAxis;
	Color color = new Color();
	// Use this for initialization
	void Start () {
		actualPeriod = Random.Range(-periodDelta, periodDelta) + period;
		rotationAxis = Random.onUnitSphere;
		Vector3 tempColor = Random.onUnitSphere;
		color.r = tempColor.x / 2;
		color.g = tempColor.y / 2;
		color.b = tempColor.z / 2;
		gameObject.GetComponent<Renderer>().material.color = color;
	}
	
	// Update is called once per frame
	void Update () {
		transform.localRotation = Quaternion.AngleAxis(360f * Time.deltaTime / actualPeriod, rotationAxis) * transform.localRotation;
	}
}
