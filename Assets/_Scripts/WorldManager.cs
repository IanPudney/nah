using UnityEngine;
using System.Collections;

public class WorldManager : MonoBehaviour {
	int playersOnElevator = 0;
	AudioSource music;
	AudioSource elevatorMusic;
	void Awake () {

	}

	// Use this for initialization
	void Start () {
		music = GetComponents<AudioSource>()[0];
		elevatorMusic = GetComponents<AudioSource>()[1];
		elevatorMusic.mute = true;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown (KeyCode.Backslash)) {
			Application.LoadLevel ("IntroScene");
		}
	}

	public void incrElevator() {
		if(playersOnElevator == 0) {
			music.mute = true;
			elevatorMusic.mute = false;
		}
		playersOnElevator++;
	}

	public void decrElevator() {
		playersOnElevator--;
		if(playersOnElevator == 0) {
			music.mute = false;
			elevatorMusic.mute = true;
		}
	}
}
