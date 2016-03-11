using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Controls : MonoBehaviour {

	// Use this for initialization
	private Text ui;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Q)) {
			Application.LoadLevel("MainMenu");	
		}
	}
}