using UnityEngine;
using System.Collections;

public class EnableOn : MonoBehaviour {
	public MonoBehaviour toEnable;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void ButtonPressed(Button button) {
		toEnable.enabled = true;
        Debug.Log("Elevator Enabled");
	}

	void ButtonReleased(Button button) {
		toEnable.enabled = false;
        Debug.Log("Elevator Disabled");
	}
}
