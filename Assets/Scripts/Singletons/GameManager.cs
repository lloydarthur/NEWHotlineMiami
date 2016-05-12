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
			StartCoroutine (TransitionGameOver());
		}
		//intializeComponents ();
		emptytest(); 
		filltest (); 
	}

	IEnumerator TransitionGameOver() {
		float fadeTime = GameObject.Find ("Game_Manager").GetComponent<Fading> ().BeginFade (1);
		yield return new WaitForSeconds (fadeTime);
		Debug.Log ("fwefasfewrfawfawfew");
		SceneManager.LoadScene("GameOver");
	}
	
	void intializeComponents() {
		if(Player == null) {
			Debug.Log (" miss Player in  GameManager");
			Player = GameObject.FindGameObjectWithTag("Player");
		}else {
			
			Debug.Log ("  player in  GameManager");
		}

		if(Score_text == null) {
			Debug.Log (" miss ST in  GameManager");
			Score_text = GameObject.FindGameObjectWithTag("Score").GetComponent<Text>();
		} else {
			Debug.Log (" Score in  GameManager");
		}
		if(Ammo_text == null) {
			Debug.Log (" miss AT in  GameManager");
			Ammo_text = GameObject.FindGameObjectWithTag("Ammo").GetComponent<Text>();
		} else {
			Debug.Log (" Ammo in  GameManager");
		}


		if(CurenntWeapon_text==null) {
			Debug.Log (" miss CW in  GameManager");
			CurenntWeapon_text = GameObject.FindGameObjectWithTag("CurenntWeapon").GetComponent<Text>();
		} else {
			Debug.Log ("CurenntWeapon in  GameManager");
		}

		if(healthbar_text==null) {
			Debug.Log (" miss HT in  GameManager");
			healthbar_text = GameObject.FindGameObjectWithTag("Health").GetComponent<Text>();
		} else {
			Debug.Log (" Healthbar in  GameManager");
		}
		if(ShotGunGui==null) {
			Debug.Log (" miss SGG in  GameManager");
			ShotGunGui = GameObject.FindGameObjectWithTag("ShotGunGui").GetComponent<Image>();
		} else {
			Debug.Log (" ShotGunGui in  GameManager");
		}

		if(HandGunGui==null) {
			Debug.Log (" miss HGG in  GameManager");
			HandGunGui= GameObject.FindGameObjectWithTag("HandgunGui").GetComponent<Image>();
		} else {
			Debug.Log (" handGunGui in  GameManager");
		}

		if(RifeGui==null) {
			Debug.Log (" miss RG in  GameManager");
			RifeGui = GameObject.FindGameObjectWithTag("RifleGUi").GetComponent<Image>();
		} else {
			Debug.Log (" RiferGui in  GameManager");
		}

		if(BulletSpawerConponet==null) {
			Debug.Log (" miss BSC in  GameManager");
			BulletSpawerConponet = GameObject.FindGameObjectWithTag ("BulletSpawer"); BulletSpawerConponet.GetComponent<BulletSpawner>();
		} else {
			Debug.Log (" RiferGui in  GameManager");
		}


		if(healthbarfilerGui==null) {
			healthbarfilerGui = GameObject.FindGameObjectWithTag("Healthbarfiler").GetComponent<Image>();
		} else {
			Debug.Log (" healthbarfilerGui in  GameManager");
		}


	}

	void textUpdater() {

		Score_text.text = "Score: " + PlayerScore;
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
		Score_text.text = "Score" + PlayerScore;
		PlayerPrefs.SetInt ("s", PlayerScore);
		if(!PlayerPrefs.HasKey("hs")){
			PlayerPrefs.SetInt ("hs", 0);
		}
		if(PlayerScore > PlayerPrefs.GetInt("hs")) {
			PlayerPrefs.SetInt ("hs", PlayerScore);
		}
	}



	void emptytest() 
	{
		if (Input.GetKey(KeyCode.L))
		{
		Player = null;
		Score_text = null;
		Ammo_text = null;
		CurenntWeapon_text= null;
		HandGunGui = null;
		ShotGunGui= null;
		RifeGui = null;
		healthbarfilerGui = null;
		BulletSpawerConponet = null;
		healthbar_text = null;
			filltest (); 
		}
	}
	void filltest() 
	{
		if (Input.GetKey(KeyCode.J))
		{
			Debug.Log ("nooooooooooooope");
			Player = GameObject.FindGameObjectWithTag("Player");
			Score_text = GameObject.FindGameObjectWithTag("Score").GetComponent<Text>();
			Ammo_text = GameObject.FindGameObjectWithTag("Ammo").GetComponent<Text>();
			CurenntWeapon_text = GameObject.FindGameObjectWithTag("CurenntWeapon").GetComponent<Text>();
			healthbar_text = GameObject.FindGameObjectWithTag("Health").GetComponent<Text>();
			HandGunGui= GameObject.FindGameObjectWithTag("HandgunGui").GetComponent<Image>();
			ShotGunGui = GameObject.FindGameObjectWithTag("ShotGunGui").GetComponent<Image>();
			RifeGui = GameObject.FindGameObjectWithTag("RifleGUi").GetComponent<Image>();
			BulletSpawerConponet = GameObject.FindGameObjectWithTag ("BulletSpawer");
			healthbarfilerGui = GameObject.FindGameObjectWithTag("Healthbarfiler").GetComponent<Image>();
		}
	}
}