using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour {

	private AudioManager2 audio;

	// Use this for initialization
	void Start () {
		audio = GameObject.Find ("AudioManager").GetComponent<AudioManager2>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D c) {
		if(c.tag == "Player") {
			GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameManager> ().IncreasePlayerScore (100);
			float rand = Random.Range(0,100);
			if(rand >= 1 && rand <= 50) {
				audio.PlayCoinSound1 ();
			}
			if(rand >= 51 && rand <= 100) {
				audio.PlayCoinSound2 ();
			}
			Destroy (gameObject);
		}
	}
}
