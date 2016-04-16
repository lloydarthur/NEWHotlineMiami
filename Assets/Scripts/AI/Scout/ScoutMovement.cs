using UnityEngine;
using System.Collections;

public class ScoutMovement : MonoBehaviour {
   
    public GameObject Player = null;//player ref
    public GameObject Enemy;//gameobject Ref
    public Transform[] wayPoints;//waypoint array, dydnamic size based 
    //public Vector3 intPlayerpos;//intial postion check for debugging 

    public bool playerFound=false;//link to projectile spawner
    public bool centuryMode = false;//simple bool for designers, choose between general patrol and century mode
    public bool DrawFOV = false;//switchs the feild of veiw visualizations off and on for dubugging
    public float rayOffset;// offset angle threshold for feild of veiw 
    public float rayDistence;// feild of view distence. how far an enemy can dectect player
    public float Rspeed = 0.1F;// rotation speed for century mode
    private float _Angle;//angle thershold for century mode e.g if this is set to 60 threshold will 
    //be 60to -60 degrees reltive to the orientation of the game object NOT world oriention of object
    public float _Period; //sets period of rotation, how many minutes per phase
    //private float patrolAngleOffset;//stes intial world rotation of object
    public int curWp;//sets waypoint target
    public int speed;//set speed 
    public int checkSeconds;
    private float _Time;//timestamp defintion for century mode
    public float angleOffset; 
   
    void Start()
    {
        Enemy = this.gameObject;//enemy intialization
        Player = GameObject.FindGameObjectWithTag("Player");//player intialization 
    
    }
    void FixedUpdate()
    {   
        playerDectection();
        if (DrawFOV) { drawFOV(); }//debug of FOV
     
        gen_Movement();
       // Debug.Log(this.transform.rotation.z*(180/Mathf.PI));
    }
    IEnumerator CenturyMode()
    {
        centuryMode = true;
        yield return new WaitForSeconds(checkSeconds);
        centuryMode = false;
    }
    void drawFOV()
    {
        Debug.DrawRay(Enemy.transform.position, Quaternion.AngleAxis(rayOffset, Enemy.transform.forward) * Enemy.transform.right, Color.red, rayDistence, false);//left offset debug
        Debug.DrawRay(Enemy.transform.position, Quaternion.AngleAxis(-rayOffset, Enemy.transform.forward) * Enemy.transform.right, Color.red, rayDistence, false);//right offset debug
        Debug.DrawRay(Enemy.transform.position, Enemy.transform.right, Color.blue, rayDistence, false);//true direction ray debug
    }
    void playerDectection()
    {
        RaycastHit2D hit = Physics2D.Raycast(Enemy.transform.position, Enemy.transform.right, rayDistence);//true direction ray
        RaycastHit2D hitL = Physics2D.Raycast(Enemy.transform.position, Quaternion.AngleAxis(rayOffset, Enemy.transform.forward) * Enemy.transform.right, rayDistence);//right offset 
        RaycastHit2D hitR = Physics2D.Raycast(Enemy.transform.position, Quaternion.AngleAxis(-rayOffset, Enemy.transform.forward) * Enemy.transform.right, rayDistence);//left offset 


        if (hit.collider == Player.GetComponent<Collider2D>() || hitL.collider == Player.GetComponent<Collider2D>() || hitR.collider == Player.GetComponent<Collider2D>())
        {
            playerFound = true;
        }
      

    }
    void gen_Movement()
    {

        if (playerFound)
        {
            Debug.Log("GRUNT SAW PLAYER!");

            Enemy.transform.LookAt(Player.transform.position);//sets direction 
            Enemy.transform.Rotate(new Vector3(0, -90, 0), Space.Self);//sets rotation
            if (Vector3.Distance(Enemy.transform.position, Player.transform.position) > 2f)//move if distance from target is greater than 1
            {
                transform.Translate(new Vector3((speed * 1.5f) * Time.deltaTime, 0, 0));// sets transform speed
            }

        }

        else
        {
            if (!centuryMode)
            {
                if (curWp < wayPoints.Length)//checks progress of patrol
                {
                    playerFound = false;//gun object de-activation
                    Enemy.transform.LookAt(wayPoints[curWp].position);//sets direction
                    Enemy.transform.Rotate(new Vector3(0, -90, 0), Space.Self);//sets rotation of game object 
                    if (Vector3.Distance(Enemy.transform.position, wayPoints[curWp].position) > 1f)//move if distance from target is greater than 1
                    {
                        transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));// sets transform speed
                    }
                    else if (Vector3.Distance(Enemy.transform.position, wayPoints[curWp].position) <= 1f)// if way point is within a distence of 1
                    {   
                        
                        StartCoroutine(CenturyMode());
                        curWp++;//change to next way point Transform
                        
                    }
                }
                else
                {
                    curWp = 0;//patrol reset 
                }
            }

            else
            {
                _Time = _Time + Time.deltaTime;//sets time stamp
                float phase = Mathf.Sin(_Time/_Period);//has sin error. fucks with offset 
                float Zref=this.transform.eulerAngles.z-angleOffset;//offset 
                _Angle=Mathf.MoveTowardsAngle(transform.eulerAngles.z,Zref,phase);
                transform.eulerAngles = new Vector3(0, 0,_Angle);//out put
                Debug.Log(Mathf.RoundToInt(this.transform.rotation.z*(180f/Mathf.PI)));
                
                #region oldMethods
                //        From = new Vector3(0f, 0f,_Angle+z);
                //        To = new Vector3(0f, 0f,- _Angle+z);
                //float t = Mathf.PingPong(Time.time * Rspeed * 2.0f, 1.0f);
                //transform.eulerAngles = Vector3.Lerp(From, To, t);
              
                
                //#region Notes
                //_Time = _Time + Time.deltaTime;//sets time stamp
                //float phase = Mathf.Sin(_Time / _Period);//creates rotation phase based on period: how many times per minute the object rotates back and forth
                //transform.rotation = Quaternion.Euler(new Vector3(Enemy.transform.rotation.x, Enemy.transform.rotation.y, 90+(phase * _Angle))); //movement output 
                //#endregion
                //Vector3 targetPosition = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z+40);
                //Vector3 oscillationDirection = this.transform.position;

                //float offset = Mathf.Sin(Time.time * WaveLength) * Amplitude;

                //Vector3 osc = offset * oscillationDirection;

                //transform.position = targetPosition + osc;
                #endregion
            }

        }
    }

    //void OnTriggerEnter2D(Collider2D other)
    //{
    //    if (other.gameObject.tag == "Pbullet")
    //    {
    //        Destroy(this.gameObject.transform.parent);
    //        GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().PlayerScore += 200;
    //    }
    //}
}