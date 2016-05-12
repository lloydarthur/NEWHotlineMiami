using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Highscores : MonoBehaviour {

	[SerializeField] Text _score, _highscore;

	// Use this for initialization
	void Start () {
		_score.text = "" + PlayerPrefs.GetInt ("s");
		_highscore.text = "" + PlayerPrefs.GetInt ("hs");
		PlayerPrefs.SetInt ("s", 0);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
