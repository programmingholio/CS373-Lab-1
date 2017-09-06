/*
    author: Zirou(Alex) Qiu
    program: PlayerMovement.cs, Unity 2D
    Description: Player move randomly
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    //Declare variables
    public float speed = 20;
    private Rigidbody2D rb2d;

    private Vector2 movement;

    // Use this for initialization
    void Start () {
        rb2d = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void FixedUpdate() {
        movement = new Vector2(Random.Range(-1.0f, 1f), Random.Range(-1.0f, 1.0f));
        rb2d.AddForce(movement * speed);
            if (Input.GetKey("up"))
                Application.Quit();
    }
}
