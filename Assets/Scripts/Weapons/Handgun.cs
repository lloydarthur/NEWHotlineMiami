using UnityEngine;
using System.Collections;

public class Handgun : MonoBehaviour {

	public SpriteRenderer render;
	public Sprite handgun;
	public Sprite glowhandgun;

	// Use this for initialization
	void Start () {
		render = GetComponent<SpriteRenderer>();
	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerStay2D (Collider2D c) {
		if (c.tag == "Player") {
			render.sprite = glowhandgun;
		}
	}

	void OnTriggerExit2D (Collider2D c) {
		if (c.tag == "Player") {
			render.sprite = handgun;
		}
	}
}
