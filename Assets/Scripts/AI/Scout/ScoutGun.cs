using UnityEngine;
using System.Collections;

public class ScoutGun : MonoBehaviour {

    public Transform SpawnerT;//reference to parent's vector 
    public GameObject projectile;//projectile prefeb reference 
    public float TimeBetweenSpawn;//sets shot frequency
    private float TimeStamp;
    public float tOffset;
    void Start()
    {
        SpawnerT = this.gameObject.GetComponentInParent<Transform>();//sets transform to parent
        TimeStamp = tOffset;
    }
    void Update()
    {
        if (SpawnerT.GetComponentInParent<ScoutMovement>().playerFound)//reverence check in grunt bahaivor script
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
