using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class PlayerMovement : MonoBehaviour {
	
	public bool playerIsdead= false;
    public bool debugHelth = false;
	// Use this for initialization
	public int PlayerMovementspeed; 

	
	// Update is called once per frame
	void Update () 
	{
		//Vector3 mousePos= Camera.main.ScreenToWorldPoint(Input.mousePosition);
		//transform.rotation = Quaternion.LookRotation (Vector3.forward* 180, mousePos- transform.position);

		if (playerIsdead == false)
		{

			playerInput ();
		}
        if(debugHelth)
        {
            GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().PlayerHealth = 20000;
        }
	}

	void 	playerInput()
	{

		if (Input.GetKey (KeyCode.W)) 
		{
			transform.Translate (Vector2.up* PlayerMovementspeed * Time.deltaTime);
		}
		if (Input.GetKey (KeyCode.A)) 
		{
			transform.Translate (Vector2.left* PlayerMovementspeed * Time.deltaTime);
		}

		if (Input.GetKey (KeyCode.S)) 
		{
			transform.Translate (Vector2.down * PlayerMovementspeed* Time.deltaTime);
		}
		if (Input.GetKey (KeyCode.D)) 
		{
			transform.Translate ( Vector2.right* PlayerMovementspeed * Time.deltaTime);
		}
        if (Input.GetKey(KeyCode.F1))
        {
            if(!debugHelth)
            {
                debugHelth = true;
            }
            else
            {
                debugHelth = false;
            }
            
        }
        if (Input.GetKey(KeyCode.F2))
        {
            SceneManager.LoadScene("Level1-1");
        }
        if (Input.GetKey(KeyCode.F3))
        {
            SceneManager.LoadScene("Level2-1");
        }
        if (Input.GetKey(KeyCode.F4))
        {
            SceneManager.LoadScene("Level3-1");
        }
        if(Input.GetKey(KeyCode.F5))
        {
            SceneManager.LoadScene("Level3-2-3-4");
        }
        if (Input.GetKey(KeyCode.F6))
        {
            SceneManager.LoadScene("Shop");
        }
        if (Input.GetKey(KeyCode.F7))
        {
            SceneManager.LoadScene("MainMenu");
        }
	/*	Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);

		RaycastHit hit = new RaycastHit ();

		if (Physics.Raycast (ray, out hit, 100))
		{
			Vector2 HitPoint = hit.point;
			//Vector2 TargetDir = HitPoint - transform.position;
			float angle = Mathf.Atan2 (TargetDir.y, TargetDir.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.AngleAxis (angle, Vector2.up);
		}*/

		Vector3 mousePos= Camera.main.ScreenToWorldPoint(Input.mousePosition);
		transform.rotation = Quaternion.LookRotation (Vector3.forward* 180, mousePos- transform.position);


	}




}
