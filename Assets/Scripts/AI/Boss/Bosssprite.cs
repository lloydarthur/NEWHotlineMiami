using UnityEngine;
using System.Collections;

public class Bosssprite : MonoBehaviour {
    public GameObject Player = null;//player ref
    public GameObject Enemy;//gameobject Ref
    public bool playerFound = false;
    void Start()
    {
        Enemy = this.gameObject;//enemy intialization
        Player = GameObject.FindGameObjectWithTag("Player");//player intialization 
    }

    void FixedUpdate()
    {
        targeting();
    }
	void targeting()
    {
        Enemy.transform.LookAt(Player.transform.position);//sets direction 
        Enemy.transform.Rotate(new Vector3(0, -90, 0), Space.Self);//sets rotation
        
    }
}
