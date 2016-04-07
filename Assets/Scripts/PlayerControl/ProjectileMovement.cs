using UnityEngine;
using System.Collections;

public class ProjectileMovement : MonoBehaviour {
	public float speed = 9;

	[SerializeField] private Vector3 myDirection = Vector3.up;
	private float time;

	// Use this for initialization
	void Start () {

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
        if (c.gameObject.tag == "grunt")
        {
            Destroy(c.gameObject);
            Destroy(gameObject);
        }
    }
}
