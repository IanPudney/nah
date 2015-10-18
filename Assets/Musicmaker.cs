using UnityEngine;
using System.Collections;

public class Musicmaker : MonoBehaviour {
	void ButtonPressed(Button unused) {
		Debug.Log ("Musicing");
		//GameObject.Find ("WorldManager").GetComponent<WorldManager>().incrElevator();
	}
	
	void ButtonReleased(Button unused) {
		Debug.Log ("Unmusicing");
		//GameObject.Find ("WorldManager").GetComponent<WorldManager>().decrElevator();
	}
}
