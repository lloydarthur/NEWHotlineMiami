using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	
	public bool playerIsdead= false;

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
	}

	void 	playerInput()
	{

		if (Input.GetKey (KeyCode.W)) 
		{
			transform.Translate (Vector2.up* PlayerMovementspeed * Time.deltaTime);
		}


		/*if (Input.GetKey (KeyCode.A)) 
		{
			transform.Translate (Vector2.left* PlayerMovementspeed * Time.deltaTime);
		}*/

		if (Input.GetKey (KeyCode.S)) 
		{
			transform.Translate (Vector2.down * PlayerMovementspeed* Time.deltaTime);
		}

		/*if (Input.GetKey (KeyCode.D)) 
		{
			transform.Translate ( Vector2.right* PlayerMovementspeed * Time.deltaTime);
		}*/


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
