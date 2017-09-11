/*########################################################
Program Description: Spawn objects by clicking

Intructor: Dr. Ziping Liu

Authors:
	Myiah Mackins
	Sarah ALdossari
	Kaitlin Wieberg
	Mark Eikel
	Zirou Qiu

Date: 9/8/2017

##########################################################*/


/*###########################################################################################################################
FUNCTIONS DESCRIPTIONS: 

RayFromCamera - When mouse is pressed, recored cursor's position and returns a ray going from camera through that position. 
				Casts a ray, from the ray position, in direction of out hit, of length of rayLenght

Generate - Create RaycastHit variable record the mours position and instantiate objects based on the positioin

Update - When mouse is press, invoke Generate() and mouse position as an argument

#############################################################################################################################*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{

    Ray myRay;      // initializing the ray
    RaycastHit hit; // initializing the raycasthit
    public GameObject ball;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
            Generate(Input.mousePosition);
        /*if (Input.GetAxis("Fire1") > 0f)
        {
            // Movement();
        }*/
    }

    public void Generate(Vector2 mousePosition)
    {
        RaycastHit hit = RayFromCamera(mousePosition, 1000.0f);
        GameObject.Instantiate(ball, hit.point, Quaternion.identity);
    }

    public RaycastHit RayFromCamera(Vector3 mousePosition, float rayLength)
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(mousePosition);
        Physics.Raycast(ray, out hit, rayLength);
        return hit;
    }
}