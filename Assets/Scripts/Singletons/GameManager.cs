using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
	#region Variables

	public int PlayerScore;
	public int RifeAmmon;
	public int ShotGunAmmon;
	public int HandGunAmmon;
	public int PlayerHealth;
	public int[] playerStartammo;
	public GameObject Player=null;
	public GameObject BulletSpawerConponet=null;
	public Vector3 PlayerStartPostion;

	private static GameManager instance;

	public Text Score_text=null;
	public Text Ammo_text=null;
	public Text healthbar_text = null;
	public Text CurenntWeapon_text=null;
	public Image ShotGunGui = null;
	public Image HandGunGui = null;
	public Image RifeGui = null;
	public Image healthbarfilerGui = null;

	#endregion

	void Awake() {
		if(instance==null){
			instance = this;
			GameObject.DontDestroyOnLoad(this.gameObject);
		}
		else {
			GameObject.Destroy(this.gameObject);
		}
		intializeComponents();
		PlayerStartPostion = Player.transform.position;
		// PlayerAmmo = playerStartammo;
		HandGunAmmon = playerStartammo [0];
		ShotGunAmmon = playerStartammo [1];
		RifeAmmon = playerStartammo [2];
		PlayerHealth = 100;
		healthbarfilerGui.fillAmount = 1;
	}

	void FixedUpdate()
	{
		textUpdater();
		if(PlayerHealth<=0) {
			SceneManager.LoadScene("GameOver");
		}
	}

	void intializeComponents() {
		if(Player == null) {
			Player = GameObject.FindGameObjectWithTag("Player");
		}else {

		}

		if(Score_text == null) {
			Score_text = GameObject.FindGameObjectWithTag("Score").GetComponent<Text>();
		} else {

		}


		if(CurenntWeapon_text==null) {
			CurenntWeapon_text = GameObject.FindGameObjectWithTag("CurenntWeapon").GetComponent<Text>();
		} else {

		}

		if(healthbar_text==null) {
			healthbar_text = GameObject.FindGameObjectWithTag("HealthBarText").GetComponent<Text>();
		} else {

		}
		if(ShotGunGui==null) {
			ShotGunGui = GameObject.FindGameObjectWithTag("ShotGunGui").GetComponent<Image>();
		} else {

		}

		if(HandGunGui==null) {
			HandGunGui= GameObject.FindGameObjectWithTag("HandGunGui").GetComponent<Image>();
		} else {

		}

		if(RifeGui==null) {
			RifeGui = GameObject.FindGameObjectWithTag("RifeGui").GetComponent<Image>();
		} else {

		}

		if(healthbarfilerGui==null) {
			healthbarfilerGui = GameObject.FindGameObjectWithTag("healthbarfiler").GetComponent<Image>();
		} else {

		}


	}

	void textUpdater() {

		Score_text.text = "" + PlayerScore;
		healthbar_text.text =   PlayerHealth + "/100"  ;

		if (BulletSpawerConponet.GetComponent<BulletSpawner>().HandGunisActive== true){
			CurenntWeapon_text.text = "Hand Gun";
			HandGunGui.enabled = true;
			ShotGunGui.enabled = false;
			RifeGui.enabled = false;
			Ammo_text.text = "AMMO: "+ /*PlayerAmmo*/ HandGunAmmon ;
		}
		else if (BulletSpawerConponet.GetComponent<BulletSpawner>().ShotGunisActive== true){
			CurenntWeapon_text.text = "Shot Gun";
			HandGunGui.enabled = false;
			ShotGunGui.enabled = true;
			RifeGui.enabled = false;
			Ammo_text.text = "AMMO: "+ /*PlayerAmmo*/ ShotGunAmmon ;
		}
		else if (BulletSpawerConponet.GetComponent<BulletSpawner>().AssaultRifleisActive== true){
			CurenntWeapon_text.text = "Rifle";
			HandGunGui.enabled = false;
			ShotGunGui.enabled = false;
			RifeGui.enabled = true;
			Ammo_text.text = "AMMO: "+ /*PlayerAmmo*/ RifeAmmon  ;
		}
	}

	public void resetPlayer() {
		Player.transform.position = PlayerStartPostion;
		PlayerStartPostion = Player.transform.position;
		//  PlayerAmmo = playerStartammo;
		PlayerHealth =  100;
		HandGunAmmon = playerStartammo [0];
		ShotGunAmmon = playerStartammo [1];
		RifeAmmon = playerStartammo [2];
	}

	public void DecreasePlayerAmmon (){
		if (BulletSpawerConponet.GetComponent<BulletSpawner>().HandGunisActive== true){
			HandGunAmmon-= 1 ;
		}
		else if (BulletSpawerConponet.GetComponent<BulletSpawner>().ShotGunisActive== true){
			ShotGunAmmon-= 2 ;
		}
		else if (BulletSpawerConponet.GetComponent<BulletSpawner>().AssaultRifleisActive== true){
			RifeAmmon-=1  ;
		}

	}


	public void DecreasePlayerHealth (int x) {
		if (PlayerHealth > 0) {
			PlayerHealth = PlayerHealth - x;
			float yup = PlayerHealth / 100.0f;
			healthbarfilerGui.fillAmount = yup;
		}

		if (PlayerHealth < 75) {
			healthbarfilerGui.color =  Color.yellow;
		} else if (PlayerHealth < 30){
			healthbarfilerGui.color = Color.red;
		}
	}

	public void IncreasePlayerScore (int x) {
		PlayerScore += x;
		Score_text.text = "" + PlayerScore;
	}
}