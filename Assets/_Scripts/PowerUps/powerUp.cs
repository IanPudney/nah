using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class powerUp : Difference{
    public AudioClip clip;
    public GameObject tempSoundObject;
    
    public enum DebuffChoice { Left, Right, Down, Up, Jump, ForceJump, LowGravity}
    public DebuffChoice debuffChoice;
    public List<GameObject> debuff = new List<GameObject>();
    Player owner;
    Player enemy;
	// Use this for initialization
	void Start () {
        
    }

    public void activate_ability() {
        GameObject hurtBox = (GameObject)Instantiate(debuff[(int)debuffChoice], enemy.gameObject.transform.position, Quaternion.identity);
        hurtBox.transform.parent = enemy.gameObject.transform;
    }
	
	void OnPlayerHit(ControllerColliderHit col){
        
        Player[] playerList = GameObject.FindObjectsOfType<Player>();
        foreach (Player player in playerList) {
            if (player.isPlayer1 != this.isPlayer1) {
                enemy = player;
            }
        }
        activate_ability();

        GameObject tempSound = Instantiate(tempSoundObject);
        AudioSource temp = tempSound.AddComponent<AudioSource>();
        temp.clip = clip;
        temp.Play();
        
        Destroy(this.gameObject);
	}
}
