using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Chase_iron_collision : MonoBehaviour {
	public void OnTriggerEnter(Collider trig){
		Debug.Log("YOOO");
		}
 
	public void OnCollisionEnter2D(Collision2D coll)
         {
			if (coll.gameObject.tag == "Chase"){	 
					SceneManager.LoadScene("MainMenu",LoadSceneMode.Single);
			}
         }
}
