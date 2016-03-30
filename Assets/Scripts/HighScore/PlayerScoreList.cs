using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PlayerScoreList : MonoBehaviour {

	public GameObject playerScoreEntryPrefab;

	ScoreManager scoreManager;

	void Start () 
    {       
		scoreManager = GameObject.FindObjectOfType<ScoreManager> ();

		if (scoreManager == null)
		{
			Debug.LogError ("You forgot to add the score manager component to a game object!");
			return;
		}
            
		while ( this.transform.childCount > 0 )
		{
			Transform c = this.transform.GetChild (0);
			c.SetParent (null);
			Destroy (c.gameObject);
		}

//		string[] names = scoreManager.GetPlayerNames ("Score");
//
//		int rank = 0;
//		foreach ( string name in names )
//		{
//			GameObject go = (GameObject)Instantiate (playerScoreEntryPrefab);
//			go.transform.SetParent(this.transform);
//
//			rank++;
//			go.transform.Find ("Rank").GetComponent<Text> ().text = rank.ToString();
//			go.transform.Find ("Name").GetComponent<Text> ().text = name;
//			go.transform.Find ("Score").GetComponent<Text> ().text = scoreManager.GetScore(name, "Score").ToString();
//		}

        int rank = 0;
        List<ScoreRecord> records = scoreManager.GetRecords();
        foreach ( ScoreRecord record in records )
        {
            GameObject go = (GameObject)Instantiate (playerScoreEntryPrefab);
            go.transform.SetParent(this.transform);
         
            rank++;
            go.transform.Find ("Rank").GetComponent<Text> ().text = rank.ToString();
            go.transform.Find ("Name").GetComponent<Text> ().text = record.Name;
            go.transform.Find ("Score").GetComponent<Text> ().text = record.Score.ToString();
            }
        }

}
