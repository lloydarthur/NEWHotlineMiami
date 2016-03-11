using UnityEngine;
using System.Collections;

public class Shotgun : MonoBehaviour {

	public SpriteRenderer render;
	public Sprite shotgun;
	public Sprite glowshotgun;

	// Use this for initialization
	void Start () {
		render = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay2D (Collider2D c) {
		if (c.tag == "Player") {
			render.sprite = glowshotgun;
		}
	}

	void OnTriggerExit2D (Collider2D c) {
		if (c.tag == "Player") {
			render.sprite = shotgun;
		}
	}
}
