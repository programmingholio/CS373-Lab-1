using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Chase_player_controller : MonoBehaviour {

	public GameObject ironman;
	//public Transform transform;
	private Rigidbody2D rb2d;

	float speed = 5;
	void Start() {
        rb2d = GetComponent<Rigidbody2D> ();
	}

	void FixedUpdate(){
        float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis ("Vertical");
		
		Vector2 movement = new Vector2 (moveHorizontal, moveVertical);

		rb2d.AddForce (movement * speed);
	}
}
