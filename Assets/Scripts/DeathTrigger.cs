using UnityEngine;
using System.Collections;
using UnityEngine.UI;




public class DeathTrigger : MonoBehaviour
{
	private int deathCount;
	public Text text;

    void OnPlayerHit(ControllerColliderHit col)
    {
        col.controller.gameObject.GetComponent<Player>().FallingDeath();
		++deathCount;
		text.text = "Deaths: " + deathCount.ToString ();
    }
	//void OnGUI(){
		//GUI.Label (new Rect (20, 20, 150, 100), "Player 1 Death Count:  " + p1deathCount.ToString ());
		//GUI.Label (new Rect (20, 50, 150, 100), "Player 2 Death Count:  " + p2deathCount.ToString ());
	//}

}
