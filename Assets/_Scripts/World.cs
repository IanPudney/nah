using UnityEngine;
using System.Collections;
using System.Collections.Generic;
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
			List<GameObject> leftChildren = GetAllChilds(gameObject);
			List<GameObject> rightChildren = GetAllChilds (duplicate);
			if(leftChildren.Count != rightChildren.Count) {
				throw new UnityException("Duplicated tree has different size");
			}
			for(int i = 0; i < leftChildren.Count; ++i) {
				leftChildren[i].AddComponent<Otherizer>();
				rightChildren[i].AddComponent<Otherizer>();
				Otherizer left = leftChildren[i].GetComponent<Otherizer>();
				Otherizer right = rightChildren[i].GetComponent<Otherizer>();
				left.other = right.gameObject;
				right.other = left.gameObject;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private List<GameObject> GetAllChilds(GameObject transformForSearch)
	{
		List<GameObject> getedChilds = new List<GameObject>();
		
		foreach (Transform trans in transformForSearch.transform)
		{
			//Debug.Log (trans.name);
			GetAllChilds ( trans.gameObject );
			getedChilds.Add ( trans.gameObject );            
		}        
		return getedChilds;
	}
}
