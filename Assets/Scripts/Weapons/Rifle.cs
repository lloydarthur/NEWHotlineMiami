using UnityEngine;
using System.Collections;

public class Rifle : MonoBehaviour {

	public SpriteRenderer render;
	public Sprite rifle;
	public Sprite glowrifle;

	// Use this for initialization
	void Start () {
		render = GetComponent<SpriteRenderer>();
	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerStay2D (Collider2D c) {
		if (c.tag == "Player") {
			render.sprite = glowrifle;
		}
	}

	void OnTriggerExit2D (Collider2D c) {
		if (c.tag == "Player") {
			render.sprite = rifle;
		}
	}
}
