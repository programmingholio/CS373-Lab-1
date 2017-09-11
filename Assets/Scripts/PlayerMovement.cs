/*########################################################
Program Description: Enables objects to move randomly

Intructor: Dr. Ziping Liu

Authors:
	Myiah Mackins
	Sarah ALdossari
	Kaitlin Wieberg
	Mark Eikel
	Zirou Qiu

Date: 9/8/2017

##########################################################*/


/*################################################################################################################################################
FUNCTIONS DESCRIPTIONS: 

Start - retrive the rigidbody component Unity

FixedUpdate - Create 2 random numbers and use them as x/y axis direction for objects's movement direction, then add force to objects with the speed

###################################################################################################################################################*/

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
    }
}
