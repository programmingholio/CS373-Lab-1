using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Chase_enemy_controller : MonoBehaviour {

	public GameObject enemy;
	public GameObject iron;

	//public Transform transform;
	private Rigidbody2D rb2d;
	List<Vector3> playerList;

	int count = 0;

	void Start() {
		playerList = iron.GetComponent<Chase_iron_pos>().playerList;	
        rb2d = GetComponent<Rigidbody2D> ();
	}

	void Update(){
		playerList = iron.GetComponent<Chase_iron_pos>().playerList;	
		transform.rotation = Quaternion.Euler (0, 0, 0);
		transform.Translate(0.0f,0.0f,0.0f);	

		//Debug.Log(playerList.Count);

		if (playerList.Count > 30) {
				//`this.transform.position = playerList[0];
				rb2d.MovePosition(playerList[0]);
		//		transform.Translate(playerList[0].x, playerList[0].y, playerList[0].z, Space.Self);
				playerList.RemoveAt(0);
		}

		transform.rotation = Quaternion.Euler (0, 0, count*36);
		count++;
		if (count > 10) { count = 0; }
	}
}
