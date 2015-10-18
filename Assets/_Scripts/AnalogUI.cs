using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AnalogUI : Difference {
    public enum Directions { Down, Right, Left, Up }
    public Camera camera;
    public Renderer[] directions;
    public Material red, green;
    public int limitCounter = 0;

	// Use this for initialization
    void Start() {
        directions = GetComponentsInChildren<Renderer>();
    }

	// Update is called once per frame
	void Update () {
        if (limitCounter < 1) {
            gameObject.SetActive(false);
        }
        transform.LookAt(camera.transform.position);
		transform.rotation = Quaternion.Euler (0, transform.rotation.eulerAngles.y, 0); 
	}



    //Call this to set a renderer color. Either red or green
    public void set_renderer(Directions direction, bool limited) {
        if (limited) {
            directions[(int)direction].material = red;
            limitCounter++;
            if (limitCounter > 0) {
                gameObject.SetActive(true);
            }
        }
        else {
            directions[(int)direction].material = green;
            limitCounter--;
            if (limitCounter == 0) {
                gameObject.SetActive(false);
            }
        }
    }
}
