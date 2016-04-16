using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D c) {
		if(c.tag == "Player") {
			GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameManager> ().IncreasePlayerScore (100);
			Destroy (gameObject);
		}
	}
}
