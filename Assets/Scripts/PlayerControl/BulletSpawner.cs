using UnityEngine;
using System.Collections;

public class BulletSpawner: MonoBehaviour {


	//public int ShotGunAmmon;
	//public int HandGunAmmon;
	//public int RifeAmmon;

	public GameManager Gamemgn=null;

	public bool ShotGunisActive=false;
	public bool HandGunisActive=false; 
	public bool AssaultRifleisActive= true; 

	public bool isShotGunAmmoEmpty= true;
	public bool isHandGunActiveEmpty= true; 
	public bool isRifleisActiveEmpty= true; 

	[SerializeField] private GameObject projectilePrefab = null;
	[SerializeField] private GameObject ShotGB = null;
	[SerializeField] private GameObject SFXmng1 = null;
	[SerializeField] private GameObject RifeB = null;
	public GameObject[] Spawnpoints = null;

	private float GunThreshold;

	public float ChanceOfRifesound1;
	public float ChanceOfRifesound2;
	public float ChanceOfRifesound3;


	public float ChanceOfShotgunsound1;
	public float ChanceOfShotgunsound2;
	public float ChanceOfShotgunsound3;

	public float ChanceOfHandgunsound1;
	public float ChanceOfHandgunsound2;
	public float ChanceOfHandgunsound3;

	// Use this for initialization

	void Start () 
	{
		//if(Gamemgn==null) {
			///Gamemgn = GameManager.FindObjectOfType();   //GameManager.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
		// Gamemgn  = (GameManager) FindObjectOfType(typeof(GameManager));
		//} else {
		//	Debug.Log (" misss game manger in  bulletSpawer");
		//}
	}
	// Update is called once per frame
	void Update () 
	{

		if (Gamemgn == null) {
			///Gamemgn = GameManager.FindObjectOfType();   //GameManager.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
			Gamemgn = (GameManager)FindObjectOfType (typeof(GameManager));
		} else {
			Debug.Log (" misss game manger in  bulletSpawer");
		}
		/*if (Input.GetMouseButtonDown(1))
		{
			//Spawn the projectile, setting its position and orientation to that of the spawner game object's transform.
			GameObject projectile = Instantiate(this.projectilePrefab) as GameObject;
			projectile.transform.position = this.gameObject.transform.position;
			projectile.transform.rotation = this.gameObject.transform.rotation;
		}*/
		//HandGunShoot ();
		if (ShotGunisActive == false && HandGunisActive == true&& AssaultRifleisActive== false&& isRifleisActiveEmpty == true)
		{
            
				HandGunShoot ();
		}
		if (ShotGunisActive == true && HandGunisActive == false && AssaultRifleisActive== false&& isHandGunActiveEmpty== true )
		{
				ShotGunShoot ();
		}
		if (ShotGunisActive == false && HandGunisActive == false && AssaultRifleisActive== true&& isShotGunAmmoEmpty == true)
		{
				RifeShoot ();
		}


		GunThreshold = Random.Range (0f, 100.0f);
	}


	public void HandGunShoot ()
	{
		if (Input.GetMouseButtonDown (1))
		{
			GameObject projectile1 = Instantiate(this.projectilePrefab) as GameObject;
			projectile1.transform.position = Spawnpoints[0].transform.position;
			projectile1.transform.rotation =  Spawnpoints[0].transform.rotation;

			//Debug.Log ("randomHandGun:"+ GunThreshold);

			if (GunThreshold < ChanceOfHandgunsound1)
			{
				SFXmng1.GetComponent<AudioManager2> ().PlayHandGunclip1 ();
				Debug.Log ("just played PlayHandGunclip1"); 
			}
			else if (GunThreshold < ChanceOfHandgunsound2)
			{
				SFXmng1.GetComponent<AudioManager2> ().PlayHandGunclip2 ();
				Debug.Log ("just played PlayHandGunclip2"); 
			}
			else if (GunThreshold < ChanceOfHandgunsound3)
			{
				SFXmng1.GetComponent<AudioManager2> ().PlayHandGunclip3 ();
				Debug.Log ("just played PlayHandGunclip3"); 
			}

			Gamemgn.GetComponent<GameManager> ().DecreasePlayerAmmon ();
			noAmmo ();
		}

	}
	public void RifeShoot ()
	{
		if (Input.GetMouseButton (1))
		{
			GameObject projectile2 = Instantiate(this.RifeB) as GameObject;
			projectile2.transform.position = Spawnpoints[0].transform.position;
			projectile2.transform.rotation =  Spawnpoints[0].transform.rotation;

			if (GunThreshold < ChanceOfRifesound1)
			{
				SFXmng1.GetComponent<AudioManager2> ().PlayRifeclip1 ();
				Debug.Log ("just played PlayRifeclip1"); 
			}
			else if (GunThreshold < ChanceOfRifesound2)
			{
				SFXmng1.GetComponent<AudioManager2> ().PlayRifeclip2 ();
				Debug.Log ("just played PlayRifeclip2"); 
			}
			else if (GunThreshold < ChanceOfRifesound3)
			{
				SFXmng1.GetComponent<AudioManager2> ().PlayRifeclip3 ();
				Debug.Log ("just played PlayRifeclip3"); 
			}
			Gamemgn.GetComponent<GameManager> ().DecreasePlayerAmmon ();
				noAmmo ();
		}
	
	}

	public void ShotGunShoot ()
	{
		if (Input.GetMouseButtonDown (1))
		{
			//Spawn the projectile, setting its position and orientation to that of the spawner game object's transform.
			GameObject projectile3 = Instantiate(this.ShotGB ) as GameObject;
			projectile3.transform.position = Spawnpoints [0].transform.position;//this.gameObject.transform.position;
			projectile3.transform.rotation =  Spawnpoints[0].transform.rotation;//this.gameObject.transform.rotation;
			GameObject projectile4 = Instantiate(this.ShotGB ) as GameObject;
			projectile4.transform.position = Spawnpoints[1].transform.position;//this.gameObject.transform.position;
			projectile4.transform.rotation =  Spawnpoints[1].transform.rotation;
			GameObject projectile5 = Instantiate(this.ShotGB ) as GameObject;
			projectile5 .transform.position = Spawnpoints [2].transform.position;//this.gameObject.transform.position;
			projectile5 .transform.rotation =  Spawnpoints[2].transform.rotation;
			GameObject projectile6 = Instantiate(this.ShotGB ) as GameObject;
			projectile6.transform.position = Spawnpoints [3].transform.position;//this.gameObject.transform.position;
			projectile6 .transform.rotation =  Spawnpoints[3].transform.rotation;
			//Debug.Log ("randomShotGun:"+ GunThreshold); 

			if (GunThreshold < ChanceOfShotgunsound1)
			{
				SFXmng1.GetComponent<AudioManager2> ().PlayShotGunclip1 ();
				Debug.Log ("just played PlayShotGunclip1"); 
			}
			else if (GunThreshold < ChanceOfShotgunsound2)
			{
				SFXmng1.GetComponent<AudioManager2> ().PlayShotGunclip2 ();
				Debug.Log ("just played PlayShotGunclip2"); 
			}
			else if (GunThreshold < ChanceOfShotgunsound3)
			{
				SFXmng1.GetComponent<AudioManager2> ().PlayShotGunclip3 ();
				Debug.Log ("just played PlayShotGunclip3"); 
			}
			Gamemgn.GetComponent<GameManager> ().DecreasePlayerAmmon ();
			noAmmo ();
		}
	}




	void noAmmo ()

	{
		if (Gamemgn.GetComponent<GameManager> ().RifeAmmon >= 0) {
			isRifleisActiveEmpty = true;

		} else
		{
			Gamemgn.GetComponent<GameManager> ().RifeAmmon = 0;
			isRifleisActiveEmpty = false; 
		}
	
		if (Gamemgn.GetComponent<GameManager> ().HandGunAmmon>= 0) 
		{
			isHandGunActiveEmpty= true; 
		} else
		{
			isHandGunActiveEmpty= false;
			Gamemgn.GetComponent<GameManager> ().HandGunAmmon= 0;

		}


		if (Gamemgn.GetComponent<GameManager> ().ShotGunAmmon>= 0) 
		{
			isShotGunAmmoEmpty= true; 
		} else
		{
			
			isShotGunAmmoEmpty= false;
			Gamemgn.GetComponent<GameManager> ().ShotGunAmmon= 0;
		}

	
	}







}

