using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour 
{
	public void LoadLevel(string Scenename) 
    {
		SceneManager.LoadScene(Scenename);
    }
        
}
