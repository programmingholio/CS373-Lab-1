/*#######################################################################
Program Description: Enables uses to click and drap the "fist" object

Intructor: Dr. Ziping Liu

Authors:
	Myiah Mackins
	Sarah ALdossari
	Kaitlin Wieberg
	Mark Eikel
	Zirou Qiu

Date: 9/8/2017

#########################################################################*/


/*#############################################################################################################################################################
FUNCTIONS DESCRIPTIONS: 

OnMouseDown - When user press the mouse, the project will detect this action, the object this action acts on, and set up the initial position of the cursor

OnMouseDrag - Make the object move with cursor by calculating the current position of hte cursor and assign object's position to the current position

###############################################################################################################################################################*/



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]

public class Drag : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private Vector3 screenPoint;
    private Vector3 offset;

    void OnMouseDown()
    {

        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }

    void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        transform.position = curPosition;
    }
}
