using UnityEngine;
using System.Collections;

public class Ghost : Difference {
    GameObject ghost;
    Vector3 ghostPosition;
    public Material transparent;

	// Use this for initialization
	void Start () {
        if (isPlayer1) {
            ghost = (GameObject)Instantiate(this.gameObject, new Vector3(1000, 0, 0), Quaternion.identity);
        }
        else {
            ghost = (GameObject)Instantiate(this.gameObject, new Vector3(-1000, 0, 0), Quaternion.identity);
        }
        ghost.gameObject.layer = 8;
        Destroy(ghost.GetComponent<Ghost>());
        Destroy(ghost.GetComponent<CharacterController>());
        Destroy(ghost.GetComponent<SphereCollider>());
        Destroy(ghost.GetComponent<Player>());
        Renderer[] multiMesh = ghost.GetComponentsInChildren<Renderer>();
        for (int i = 0; i < multiMesh.Length; i++) {
            multiMesh[i].material = transparent;
        }
	}
	
	// Update is called once per frame
	void Update () {
        //Calculate adjusted position
        ghostPosition = this.transform.position;
        if (isPlayer1)
            ghostPosition.x += 1000f;
        else
            ghostPosition.x -= 1000f;
        ghost.transform.position = ghostPosition;
        //Give same Vector3 angle
        ghost.transform.rotation = this.transform.rotation;
	}
}
