using UnityEngine;
using System.Collections;

public class uii : MonoBehaviour {
	private static uii instance;
	// Use this for initialization
	void Awake() {


		if(instance==null)
		{
			instance = this;
			GameObject.DontDestroyOnLoad(this.gameObject);
		}
		else {
			GameObject.Destroy(this.gameObject);
		}


	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
