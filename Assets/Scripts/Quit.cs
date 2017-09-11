/*########################################################
Program Description: Enable quie functionality

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

QuitGame - This function is linked with UI buttion, when button is presssed, this function will be invoked and exit the game

#############################################################################################################################*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quit : MonoBehaviour {

	public void QuitGame()
    {
        Application.Quit();
    }
}
