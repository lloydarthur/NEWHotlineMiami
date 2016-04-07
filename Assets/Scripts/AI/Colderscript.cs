using UnityEngine;
using System.Collections;

public class Colderscript : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Pbullet")
        {
            Destroy(this.gameObject.transform.parent.gameObject);
            GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().PlayerScore += 200;
        }
    }
}
