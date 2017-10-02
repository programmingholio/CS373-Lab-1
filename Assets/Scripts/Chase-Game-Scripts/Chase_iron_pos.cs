using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase_iron_pos : MonoBehaviour {

	public List<Vector3> playerList;
	public GameObject iron;

	void Start() {
		playerList = new List<Vector3>();	
	}

	void print_v3 (Vector3 v){
		Debug.Log(v.x + " " + v.y + " " + v.z);
	}
	void FixedUpdate(){
		Vector3 iron_pos = iron.transform.position;
		
		if (playerList.Count == 0 || iron_pos != playerList[playerList.Count-1]){
				playerList.Add(iron_pos);
		}
	}

}
