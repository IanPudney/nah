using UnityEngine;
using System.Collections;

public class TimedDestruction : MonoBehaviour {
    public float timeToDie;
    float timeTracker;

	// Use this for initialization
	void Start () {
        timeTracker = timeToDie + Time.time;
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.time > timeTracker) {
            Destroy(this.gameObject);

        }
	}
}
