using UnityEngine;
using System.Collections;

public class HS_Test : MonoBehaviour {

    private GameManager gm;
    private ScoreManager sm;

    public void IncreaseScore()
    {
        gm.PlayerScore += 100;
    }

    public void GameOver()
    {
       
        sm.SetScore(gm.PlayerName, gm.PlayerScore);
       
        sm.SaveHighScores();

        GameObject.Destroy(GameObject.Find("Game_Manager"));
        gm = null;
      
        GameObject.Find("SceneLoader").GetComponent<SceneLoader>().LoadLevel("HighScores");

    }

    void Start () 
    {  
        gm = GameObject.Find("Game_Manager").GetComponent<GameManager>();   
        sm = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();

        sm.LoadHighScores();

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
