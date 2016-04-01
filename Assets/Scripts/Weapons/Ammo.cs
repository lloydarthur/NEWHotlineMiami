using UnityEngine;
using System.Collections;

public class Ammo : MonoBehaviour {


	public SpriteRenderer render;
	public Sprite AmmoSprite;
	public Sprite glowAmmo;

	// Use this for initialization
	void Start () 
	{
		render = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void OnTriggerStay2D (Collider2D c) {
		if (c.tag == "Player") {
			render.sprite = glowAmmo;
		}
	}

	void OnTriggerExit2D (Collider2D c) {
		if (c.tag == "Player") {
			render.sprite = AmmoSprite;
		}
	}
}
