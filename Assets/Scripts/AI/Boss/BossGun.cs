using UnityEngine;
using System.Collections;

public class BossGun : MonoBehaviour {

    public Transform SpawnerT;//reference to parent's vector 
    public GameObject projectile;//projectile prefeb reference 
    public float TimeBetweenSpawn;//sets shot frequency
    private float TimeStamp;
    public bool playerfound;
    void Start()
    {
        SpawnerT = this.gameObject.GetComponentInParent<Transform>();//sets transform to parent
        TimeStamp = .25f;
    }
    void FixedUpdate()
    {
       
        if (GameObject.FindGameObjectWithTag("bossGun").GetComponent<Bosssprite>().playerFound)//reverence check in grunt bahaivor script
        {
            if (Time.time >= TimeStamp)
            {
                GameObject projectile = Instantiate(this.projectile) as GameObject;//spawns projectile
                projectile.transform.position = SpawnerT.transform.position;//sets intial position of projectile
                projectile.transform.eulerAngles = SpawnerT.transform.eulerAngles;//sets intial vector of projectile
                TimeStamp = Time.time + TimeBetweenSpawn;//updates timestamp
            }
        }
        else
        {

        }
    }
}
