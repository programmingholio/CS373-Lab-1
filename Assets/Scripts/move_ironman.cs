using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_ironman : MonoBehaviour {
	public float speed = 1;
	public GameObject iron;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		speed++;	
		 transform.Translate(Vector3.right * Time.deltaTime * speed/20);	
	}
}
