using UnityEngine;
using System.Collections;
public class World : MonoBehaviour {
	bool isPlayer1 = true;
	// Use this for initialization
	void Start () {
		if(isPlayer1) {
			GameObject duplicate = GameObject.Instantiate(gameObject, 
			                                              transform.localPosition + new Vector3(1000, 0, 0), 
			                                              transform.rotation) as GameObject;
			duplicate.GetComponent<World>().isPlayer1 = false;
			foreach(Difference diff in duplicate.GetComponentsInChildren<Difference>()) {
				diff.isPlayer1 = false;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
