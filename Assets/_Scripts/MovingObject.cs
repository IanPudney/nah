using UnityEngine;
using System.Collections;

public class MovingObject : MonoBehaviour {
	public Vector3 end1;
	public Vector3 end2;
	public float period;
	public float fraction = 0;
    public bool loop = false;
	bool direction = true;

	int pressTrack = 0;

	// Use this for initialization
	void Start () {
		end1 += transform.localPosition;
		end2 += transform.localPosition;
	}
	
	// Update is called once per frame
	void Update () {
		transform.localPosition = Vector3.Lerp(end1, end2, fraction);
		if(direction) {
			fraction += 2 * Time.deltaTime / period;
			if(fraction > 1) {
				direction = false;
			}
		} else {
			fraction -= 2 * Time.deltaTime / period;
			if(fraction < 0) {
				direction = true;
			}
		}
    }
}
