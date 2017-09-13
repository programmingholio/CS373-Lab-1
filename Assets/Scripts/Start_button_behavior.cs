using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Start_button_behavior : MonoBehaviour {
	public Button start_button;

	// Use this for initialization
	void Start () {
		Button btn = start_button.GetComponent<Button>();
		btn.onClick.AddListener(StartOnClick);
				
	}
	
	void StartOnClick(){
		 Debug.Log("Start game!");
		 SceneManager.LoadScene("testing",LoadSceneMode.Single);
	}
	// Update is called once per frame
	void Update () {
				
	}
}
