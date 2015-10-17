using UnityEngine;
using System.Collections;




public class DeathTrigger : MonoBehaviour
{

    void OnPlayerHit(ControllerColliderHit col)
    {
        col.controller.gameObject.GetComponent<Player>().FallingDeath();
    }

}
