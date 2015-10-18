using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//This is the base class to affect the other player
public class powerUpAffector : MonoBehaviour {
    public enum DebuffChoice { DirectionalLimit }
    public DebuffChoice debuffChoice;

    public List<GameObject> debuff = new List<GameObject>();
    Player owner;
    Player enemy;

	// Use this for initialization. Add in the player's ability list
	public void CustomStart () {
        owner = this.transform.GetComponentInParent<Player>();
        //owner.abilityList.Add(this);
        Player[] playerList = GameObject.FindObjectsOfType<Player>();
        foreach (Player player in playerList) {
            if (player != owner) {
                enemy = player;
            }
        }
        activate_ability();
	}

    //Attach the debuff to enemy player
    public void activate_ability() {
        GameObject hurtBox = (GameObject) Instantiate(debuff[(int)debuffChoice], enemy.gameObject.transform.position, Quaternion.identity);
        hurtBox.transform.parent = enemy.gameObject.transform;
    }
}
