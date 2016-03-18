﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    #region Variables
   
    public int PlayerLives;
    public int PlayerScore;
	public int RifeAmmon;
	public int ShotGunAmmon;
	public int HandGunAmmon;
    //public int PlayerAmmo;
    public int PlayerHealth;
    public int[] playerStartammo;
    public GameObject Player=null;
	public GameObject BulletSpawerConponet=null;
    public Vector3 PlayerStartPostion;

    private static GameManager instance;

    public Text Score_text=null;
    public Text Life_text=null;
    public Text Ammo_text=null;
    #endregion

    void Awake() {
        if(instance==null)
        {
            instance = this;
            GameObject.DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            GameObject.Destroy(this.gameObject);
        }
        intializeComponents();
        PlayerStartPostion = Player.transform.position;
       // PlayerAmmo = playerStartammo;
		HandGunAmmon = playerStartammo [0];
		ShotGunAmmon = playerStartammo [1];
		RifeAmmon = playerStartammo [2];
    }

    void FixedUpdate()
    {
        textUpdater();
        if(PlayerLives<=0) {
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

        if(Life_text == null) {
            Life_text = GameObject.FindGameObjectWithTag("Lives").GetComponent<Text>();
        } else {

        }

        if(Ammo_text==null) {
            Ammo_text = GameObject.FindGameObjectWithTag("Ammo").GetComponent<Text>();
        } else {

        }
    }

    void textUpdater() {
        Life_text.text = "LIVES: " + PlayerLives;
        Score_text.text = "SCORE: " + PlayerScore;



		if (BulletSpawerConponet.GetComponent<BulletSpawner>().HandGunisActive== true)
		{
			Ammo_text.text = "AMMO: "+ /*PlayerAmmo*/ HandGunAmmon ;
		}
		else if (BulletSpawerConponet.GetComponent<BulletSpawner>().ShotGunisActive== true)
		{
			Ammo_text.text = "AMMO: "+ /*PlayerAmmo*/ ShotGunAmmon ;
		}
		else if (BulletSpawerConponet.GetComponent<BulletSpawner>().AssaultRifleisActive== true)
		{
			Ammo_text.text = "AMMO: "+ /*PlayerAmmo*/ RifeAmmon  ;
		}
    }
    
    public void resetPlayer() {
        Player.transform.position = PlayerStartPostion;
        PlayerStartPostion = Player.transform.position;
      //  PlayerAmmo = playerStartammo;
    }


	public void DecreasePlayerAmmon ()
	{
		if (BulletSpawerConponet.GetComponent<BulletSpawner>().HandGunisActive== true)
		{
			 HandGunAmmon-= 1 ;
		}
		else if (BulletSpawerConponet.GetComponent<BulletSpawner>().ShotGunisActive== true)
		{
			ShotGunAmmon-= 2 ;
		}
		else if (BulletSpawerConponet.GetComponent<BulletSpawner>().AssaultRifleisActive== true)
		{
			RifeAmmon-=1  ;
		}
	
	}
}