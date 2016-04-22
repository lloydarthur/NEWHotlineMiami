using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerCollision : MonoBehaviour {

	//Declarations
	public GameObject player;
	public Rigidbody2D riflePrefab, pistolPrefab, shotgunPrefab;
	public SpriteRenderer render, levelindicator;
	public Sprite playerPistolSprite, playerShotgunSprite, playerRifleSprite;
	private string currentGun = "rifle";
	private bool gunPickedUpConfirm = false;

	public GameObject BulletSpawner;
	public Camera camera;

	void start() {
		//Grab the sprite we are going to change later on (player)
		render = GetComponent<SpriteRenderer>();
		levelindicator = GetComponent<SpriteRenderer>();
		levelindicator.enabled = false;
	}

	IEnumerator Level2() {
		float fadeTime = GameObject.Find("Game_Manager").GetComponent<Fading>().BeginFade(1);
		yield return new WaitForSeconds(fadeTime);
		SceneManager.LoadScene ("Level2-1");
	}
	IEnumerator Level2_1EndTrigger() {
		float fadeTime = GameObject.Find("Game_Manager").GetComponent<Fading>().BeginFade(1);
		yield return new WaitForSeconds(fadeTime);
		SceneManager.LoadScene ("Level3-1");
	}
	IEnumerator Level3_1EndTrigger() {
		float fadeTime = GameObject.Find("Game_Manager").GetComponent<Fading>().BeginFade(1);
		yield return new WaitForSeconds(fadeTime);
		SceneManager.LoadScene ("Level3-2-3-4");
	}
	IEnumerator Level3_2EndTrigger() {
		float fadeTime = GameObject.Find ("Game_Manager").GetComponent<Fading> ().BeginFade (1);
		yield return new WaitForSeconds (fadeTime);
		fadeTime = GameObject.Find ("Game_Manager").GetComponent<Fading> ().EndFade();
		player.transform.position = new Vector3 (-146, -29);
		camera.transform.position = new Vector3 (-146, -29, -10);
	}
	IEnumerator Level3_3EndTrigger() {
		float fadeTime = GameObject.Find ("Game_Manager").GetComponent<Fading> ().BeginFade (1);
		yield return new WaitForSeconds (fadeTime);
		fadeTime = GameObject.Find ("Game_Manager").GetComponent<Fading> ().EndFade();
		player.transform.position = new Vector3 (-283, -78);
		camera.transform.position = new Vector3 (-283, -78, -10);
	}
	IEnumerator Level3_2BackTrigger() {
		float fadeTime = GameObject.Find ("Game_Manager").GetComponent<Fading> ().BeginFade (1);
		yield return new WaitForSeconds (fadeTime);
		fadeTime = GameObject.Find ("Game_Manager").GetComponent<Fading> ().EndFade();
		player.transform.position = new Vector3 (-36, -26);
		camera.transform.position = new Vector3 (-36, -26, -10);
	}
	IEnumerator Level3_3BackTrigger() {
		float fadeTime = GameObject.Find ("Game_Manager").GetComponent<Fading> ().BeginFade (1);
		yield return new WaitForSeconds (fadeTime);
		fadeTime = GameObject.Find ("Game_Manager").GetComponent<Fading> ().EndFade();
		player.transform.position = new Vector3 (-182, -80);
		camera.transform.position = new Vector3 (-182, -80, -10);
	}
	IEnumerator ShopTrigger() {
		float fadeTime = GameObject.Find("Game_Manager").GetComponent<Fading>().BeginFade(1);
		yield return new WaitForSeconds(fadeTime);
		SceneManager.LoadScene ("Shop");
	}


	//Creates gun prefab on the ground after the player switches their weapon
	void instGun() {
		//Instantiate prefabs depending on what gun the player dropped
		switch(currentGun) {
			case "rifle":
				Instantiate(riflePrefab, player.transform.position, Quaternion.identity);
				break;
			case "pistol":
				Instantiate(pistolPrefab, player.transform.position, Quaternion.identity);
				break;
			case "shotgun":
				Instantiate(shotgunPrefab, player.transform.position, Quaternion.identity);
				break;
			default:
				break;
		}
	}

	//When triggers collide
	void OnTriggerEnter2D (Collider2D c) {
		if (c.tag == "Level1EndTrigger") {
			levelindicator.enabled = true;
		}

	}

	//When triggers stay collided
	void OnTriggerStay2D (Collider2D c) {
		//If player is currently colliding with PISTOL and presses 'e', drop current weapon,
		//change sprite, update polygon collider and destroy the gun sprite on the ground.
		if (Input.GetKeyDown (KeyCode.E)) {
			if (c.tag == "Level1EndTrigger") {
				StartCoroutine (Level2());
			}
			if (c.tag == "Level2-1EndTrigger") {
				StartCoroutine (Level2_1EndTrigger());
			}
			if (c.tag == "Level3-1EndTrigger") {
				StartCoroutine (Level3_1EndTrigger());
			}
			if (c.tag == "Level3-2EndTrigger") {
				StartCoroutine (Level3_2EndTrigger());
			}
			if (c.tag == "Level3-3EndTrigger") {
				StartCoroutine (Level3_3EndTrigger());
			}
			if (c.tag == "Level3-2BackTrigger") {
				StartCoroutine (Level3_2BackTrigger());
			}
			if (c.tag == "Level3-3BackTrigger") {
				StartCoroutine (Level3_3BackTrigger());
			}
			if (c.tag == "ShopTrigger") {
				StartCoroutine (ShopTrigger());
			}
		}

		if (c.tag == "Handgun" && currentGun != "pistol")  {
			if (Input.GetKeyDown(KeyCode.E)) {
				if (gunPickedUpConfirm == false) {
					instGun ();
					render.sprite = playerPistolSprite;
					Destroy (GetComponent<PolygonCollider2D> ());
					gameObject.AddComponent<PolygonCollider2D> ();
					Destroy (c.gameObject);
					currentGun = "pistol";
					gunPickedUpConfirm = true;
					BulletSpawner.GetComponent<BulletSpawner>().ShotGunisActive= false;
					BulletSpawner.GetComponent<BulletSpawner>().HandGunisActive= true;
					BulletSpawner.GetComponent<BulletSpawner> ().AssaultRifleisActive = false;
				}
			}
		}

		//If player is currently colliding with RIFLE and presses 'e', drop current weapon,
		//change sprite, update polygon collider and destroy the gun sprite on the ground.
		if (c.tag == "Rifle" && currentGun != "rifle") { 
			if (Input.GetKeyDown(KeyCode.E)) {
				if (gunPickedUpConfirm == false) {
					instGun();
					render.sprite = playerRifleSprite;
					Destroy(GetComponent<PolygonCollider2D>());
					gameObject.AddComponent<PolygonCollider2D>();
					Destroy(c.gameObject);
					currentGun = "rifle";
					gunPickedUpConfirm = true;
					BulletSpawner.GetComponent<BulletSpawner>().ShotGunisActive= false;
					BulletSpawner.GetComponent<BulletSpawner>().HandGunisActive= false;
					BulletSpawner.GetComponent<BulletSpawner> ().AssaultRifleisActive = true;
				}
			}
		}

		//If player is currently colliding with SHOTGUN and presses 'e', drop current weapon,
		//change sprite, update polygon collider and destroy the gun sprite on the ground.
		if (c.tag == "Shotgun" && currentGun != "shotgun") {
			if (Input.GetKeyDown(KeyCode.E)) {
				if (gunPickedUpConfirm == false) {
					instGun();
					render.sprite = playerShotgunSprite;
					Destroy(GetComponent<PolygonCollider2D>());
					gameObject.AddComponent<PolygonCollider2D>();
					Destroy(c.gameObject);
					currentGun = "shotgun";
					gunPickedUpConfirm = true;
					BulletSpawner.GetComponent<BulletSpawner>().ShotGunisActive= true;
					BulletSpawner.GetComponent<BulletSpawner>().HandGunisActive= false;
					BulletSpawner.GetComponent<BulletSpawner> ().AssaultRifleisActive = false;

				}
			}
		}
		if (Input.GetKeyUp(KeyCode.E)) {
			gunPickedUpConfirm = false;
		}
	}
}
