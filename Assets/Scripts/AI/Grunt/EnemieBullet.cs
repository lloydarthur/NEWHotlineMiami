using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

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
		if (c.tag == "Player") {
			if (GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().PlayerHealth >= 1){
				
				GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameManager> ().DecreasePlayerHealth (10);
			}

			if (GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().PlayerHealth <= 0){
				SceneManager.LoadScene ("GameOver");
			}
			Destroy (this.gameObject);
		}
    }
    void OnCollisionEnter2D(Collider2D other)
    {
        if(other.gameObject.tag=="Level")
        {
            Destroy(this.gameObject);
        }
    }


}
