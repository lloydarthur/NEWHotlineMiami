using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;

public class ScoreRecord 
{
    private string name;
    public string Name 
    {
        get
        {
            return name;
        }
    }

    private int score;
    public int Score
    {
        get
        {
            return score;
        }
    }

    public ScoreRecord ( string _name, int _score)
    {
        this.name  = _name;
        this.score = _score;
    }
        
}

public class ScoreManager : MonoBehaviour
{
	// Dictionary<string, Dictionary<string, int>> playerScores;

    List<ScoreRecord> scoreRecords; 

    private string highScoreScoreKey = "HighScoreScore";
    private string highScoreNameKey  = "HighScoreName";

    #region Singleton

    private static ScoreManager instance = null;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            GameObject.DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            GameObject.Destroy(this.gameObject);
        }
    }

    #endregion Singleton

	void Start () 
	{
		//SetScore ("Andre Simon", 500);
    }

	void Init()
	{
//		if ( playerScores == null )
//			playerScores = new Dictionary<string, Dictionary<string, int>>();

        if ( scoreRecords == null)
            scoreRecords = new List<ScoreRecord>();

	}
        
    #region Dictionary Version
//    public int GetScore (string username, string scoreType)
//	{
//		Init ();
//
//		if (playerScores.ContainsKey (username)) {
//			if (playerScores [username].ContainsKey (scoreType))
//				return playerScores [username] [scoreType];
//			else
//				return 0;	
//		} else
//			return 0;
//	}
//
//	public void SetScore (string username, string scoreType, int value)
//	{
//		Init ();
//
//		if (playerScores.ContainsKey (username) == false)
//			playerScores [username] = new Dictionary<string, int> ();
//		
//		playerScores [username] [scoreType] = value;
//			
//	}
//
//	public void ChangeScore (string username, string scoreType, int amount)
//	{
//		Init ();
//
//		int currScore = GetScore (username, scoreType);
//		SetScore (username, scoreType, currScore + amount);
//	}
//
//	public string[] GetPlayerNames()
//	{
//		Init ();
//
//		return playerScores.Keys.ToArray ();
//	}
//
//	public string[] GetPlayerNames( string sortingScoreType )
//	{
//		Init ();
//
//		return playerScores.Keys.OrderByDescending( n => GetScore(n, sortingScoreType)).ToArray();
//	}
    #endregion 

    #region List Version

    private static int CompareByScore(ScoreRecord i1, ScoreRecord i2)
    {
        return -1 * i1.Score.CompareTo(i2.Score);
    }

    public void SetScore (string username, int value)
    {
        if (value <= 0)
            return;
        
        Init ();

        scoreRecords.Add(new ScoreRecord(username, value));
        scoreRecords.Sort(CompareByScore);

        // Limit to 10
        int size = scoreRecords.Count;
    
        int diff = ( size > 10 ? size - 10 : 0);

        for (int x = 1; x <= diff; x++)
            scoreRecords.RemoveAt(10  - 1 + x);
    }
     
    public List<ScoreRecord> GetRecords()
    {
        Init ();

        return scoreRecords;
    }

    #endregion 

    public void LoadHighScores()
    {
        Init();

        int rank = 0;

        scoreRecords.Clear();

        for ( int x = 1; x <= 10; x++)
        {
            rank++;
            if (PlayerPrefs.HasKey(highScoreNameKey + rank))
                SetScore(PlayerPrefs.GetString(highScoreNameKey + rank), PlayerPrefs.GetInt(highScoreScoreKey + rank));
            else
                break;
        }
    }

    public void SaveHighScores()
    {
       int rank = 0;
        ClearHighScores();

        foreach ( ScoreRecord record in scoreRecords )
        {
            rank++;
            PlayerPrefs.SetString(highScoreNameKey + rank, record.Name);
            PlayerPrefs.SetInt(highScoreScoreKey + rank, record.Score);
        }

        PlayerPrefs.Save();
    }

    private void ClearHighScores()
    {
        for ( int x = 1; x <= 10; x++)
        {
            if (PlayerPrefs.HasKey(highScoreNameKey + x))
                PlayerPrefs.DeleteKey(highScoreNameKey + x);
        }

    }
}
