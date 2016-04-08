using UnityEngine;
using System.Collections;

public class EnemieBullet : MonoBehaviour
{
    public int speed;
    public float destroyTime;

    void Update()
    {
        Move();
        Destroy(this.gameObject, destroyTime);
    }
    void Move()
    {
        transform.Translate(new Vector3(0, speed * Time.deltaTime, 0));
    }
    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.tag == "Player"){
			Destroy (c.gameObject);
        }
		if (c.tag == "Level"){
			Destroy (this.gameObject);
		}
    }


}
