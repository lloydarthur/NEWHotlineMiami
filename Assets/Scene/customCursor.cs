using UnityEngine;
using System.Collections;

public class customCursor : MonoBehaviour {

	//Declarations
	public Texture cursorImage;

	// Use this for initialization
	void Start () {
		Cursor.visible = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI() {
		Vector3 mousePos = Input.mousePosition;
		Rect pos = new Rect(mousePos.x, Screen.height - mousePos.y, cursorImage.width, cursorImage.height);
		GUI.Label(pos, cursorImage);
	}
}