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
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().PlayerLives < 0)
            {
                if (GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().PlayerHealth < 0)
                {
                    GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().PlayerHealth--;
                }
                else
                {
                    GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().PlayerLives--;
                }
            }
            else
            {
                GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().resetPlayer();
            }
        }
    }


}
