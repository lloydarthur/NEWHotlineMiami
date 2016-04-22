using UnityEngine;
using System.Collections;

public class PlayerTrigger : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag=="Player")
        {
            GameObject.FindGameObjectWithTag("bossGun").GetComponent<Bosssprite>().playerFound = true;
        }
    }
}
