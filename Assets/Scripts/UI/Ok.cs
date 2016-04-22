using UnityEngine.UI;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Ok : MonoBehaviour {
public Text ButtonName;

	// Use this for initialization
	void Start () {
		ButtonName.text = "Done";
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void click()
	{
		//SET PLAYER VARIABLE HERE
		Debug.Log("ewfqwef");
		SceneManager.LoadScene("GameOver");
	}
}
