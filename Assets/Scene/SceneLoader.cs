using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {


	public void LoadLevel_1(string Scenename) {
		SceneManager.LoadScene(Scenename);
    }
}
