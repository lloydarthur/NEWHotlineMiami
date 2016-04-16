using UnityEngine.UI;
using UnityEngine;
using System.Collections;

public class Letter : MonoBehaviour {
public string letter;
public Text ButtonName;
public Text Player;

	// Use this for initialization
	void Start () {
		ButtonName.text = letter;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void click()
	{
		Player.text += letter;
	}
}
