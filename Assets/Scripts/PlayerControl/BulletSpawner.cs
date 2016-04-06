using UnityEngine;
using System.Collections;

public class BulletSpawner: MonoBehaviour {

	public bool ShotGunisActive=false;
	public bool HandGunisActive=false; 
	public bool AssaultRifleisActive= true; 

	[SerializeField] private GameObject projectilePrefab = null;
	[SerializeField] private GameObject ShotGB = null;
	[SerializeField] private GameObject RifeB = null;
	public GameObject[] Spawnpoints = null;
	// Use this for initialization

	void Start () 
	{
		
	}
	// Update is called once per frame
	void Update () 
	{
		/*if (Input.GetMouseButtonDown(1))
		{
			//Spawn the projectile, setting its position and orientation to that of the spawner game object's transform.
			GameObject projectile = Instantiate(this.projectilePrefab) as GameObject;
			projectile.transform.position = this.gameObject.transform.position;
			projectile.transform.rotation = this.gameObject.transform.rotation;
		}*/
		//HandGunShoot ();
		if (ShotGunisActive == false && HandGunisActive == true&& AssaultRifleisActive== false)
		{
			HandGunShoot ();
		}
		if (ShotGunisActive == true && HandGunisActive == false && AssaultRifleisActive== false )
		{
			ShotGunShoot ();
		}
		if (ShotGunisActive == false && HandGunisActive == false && AssaultRifleisActive== true)
		{
			RifeShoot ();
		}



	}


	public void HandGunShoot ()
	{
		if (Input.GetMouseButtonDown (1))
		{
			GameObject projectile1 = Instantiate(this.projectilePrefab) as GameObject;
			projectile1.transform.position = Spawnpoints[0].transform.position;
			projectile1.transform.rotation =  Spawnpoints[0].transform.rotation;
		}
	}
	public void RifeShoot ()
	{
		if (Input.GetMouseButton (1))
		{
			GameObject projectile2 = Instantiate(this.RifeB) as GameObject;
			projectile2.transform.position = Spawnpoints[0].transform.position;
			projectile2.transform.rotation =  Spawnpoints[0].transform.rotation;
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
		}
	}
}
