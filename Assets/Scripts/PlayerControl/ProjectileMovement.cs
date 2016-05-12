using UnityEngine;
using System.Collections;

public class ProjectileMovement : MonoBehaviour {
	public float speed = 9;
	[SerializeField] private Rigidbody2D coinPrefab;
	[SerializeField] private Vector3 myDirection = Vector3.up;
	private float time;
	private AudioManager2 audio;

	// Use this for initialization
	void Start () {
		audio = GameObject.Find ("AudioManager").GetComponent<AudioManager2>();
	}
		
	// Update is called once per frame
	void Update () {
		this.transform.Translate(this.myDirection * this.speed * Time.deltaTime);
		time += Time.deltaTime;
		if(time >= 1) {
			Destroy(gameObject);
		}
	}
		
    void OnCollisionEnter2D (Collision2D c) {
        if (c.gameObject.tag == "Level") {
            Destroy(gameObject);
        }
        if (c.gameObject.tag == "grunt") {
			float rand = Random.Range(0,100);
			if(rand > 50) {
				Instantiate (coinPrefab, this.transform.position, Quaternion.identity);
			}
			rand = Random.Range(0,100);
			if(rand >= 1 && rand <= 33) {
				audio.PlayHitSound1 ();
			}
			if(rand >= 34 && rand <= 66) {
				audio.PlayHitSound2 ();
			}
			if(rand >= 67 && rand <= 100) {
				audio.PlayHitSound3 ();
			}
             if (c.gameObject.tag == "Boss") {

                 GameObject.FindGameObjectWithTag("Boss").GetComponent<BossBaseMovement>().bossHealth -= 10;
			    
			}
            Destroy(c.gameObject);
            Destroy(gameObject);
        }
    }
}
