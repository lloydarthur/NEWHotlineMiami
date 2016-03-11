using UnityEngine;
using System.Collections;

public class PlayMainMenu : MonoBehaviour {
    GameObject MusicMNG;
	void Awake()
    {
        MusicMNG = GameObject.FindGameObjectWithTag("MusicMng");
        MusicMNG.GetComponent<MusicManager>().PlayMainMenu();
    }
}
