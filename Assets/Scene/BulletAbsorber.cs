using UnityEngine;
using System.Collections;

public class BulletAbsorber : MonoBehaviour {

void OnTriggerEnter2D(Collider2D other)
{
	if (other.tag == "Pbullet")
	{
		Destroy(other.gameObject);
	}
}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
