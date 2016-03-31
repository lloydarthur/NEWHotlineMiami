using UnityEngine;
using System.Collections;

public class GruntMovement : MonoBehaviour {
    #region Variables
    public GameObject Player = null;//player ref
    public GameObject Enemy;//gameobject Ref
    public Transform[] wayPoints;//waypoint array, dydnamic size based 
    public Vector3 intPlayerpos;//intial postion check for debugging 

    public bool playerFound;//link to projectile spawner
    public bool centuryMode = false;//simple bool for designers, choose between general patrol and century mode
    public bool DrawFOV = false;//switchs the feild of veiw visualizations off and on for dubugging
    public float rayOffset;// offset angle threshold for feild of veiw 
    public float rayDistence;// feild of view distence. how far an enemy can dectect player
    public float Rspeed = 0.1F;// rotation speed for century mode
    public float _Angle;//angle thershold for century mode e.g if this is set to 60 threshold will 
    //be 60to -60 degrees reltive to the orientation of the game object NOT world oriention of object
    public float _Period; //sets period of rotation, how many minutes per phase
    public float patrolAngleOffset;//stes intial world rotation of object
    public int curWp;//sets waypoint target
    public int speed;//set speed 

    private float _Time;//timestamp defintion for century mode

   // public int Health;
    //public int Damage;
    #endregion
    #region Functions
    void Start()
    {
        Enemy = this.gameObject;//enemy intialization
        Player = GameObject.FindGameObjectWithTag("Player");//player intialization 
    }
    void FixedUpdate()
    {
        if (DrawFOV) { drawFOV(); }//debug of FOV
        gen_Movement();
    }
    void drawFOV()
    {
        Debug.DrawRay(Enemy.transform.position, Quaternion.AngleAxis(rayOffset, Enemy.transform.forward) * Enemy.transform.right, Color.red, rayDistence, false);//left offset debug
        Debug.DrawRay(Enemy.transform.position, Quaternion.AngleAxis(-rayOffset, Enemy.transform.forward) * Enemy.transform.right, Color.red, rayDistence, false);//right offset debug
        Debug.DrawRay(Enemy.transform.position, Enemy.transform.right, Color.blue, rayDistence, false);//true direction ray debug
    }
    void gen_Movement()
    {
        #region FOV Def
        RaycastHit2D hit = Physics2D.Raycast(Enemy.transform.position, Enemy.transform.right, rayDistence, 4);//true direction ray
        RaycastHit2D hitL = Physics2D.Raycast(Enemy.transform.position, Quaternion.AngleAxis(rayOffset, Enemy.transform.forward) * Enemy.transform.right, rayDistence, 1);//right offset 
        RaycastHit2D hitR = Physics2D.Raycast(Enemy.transform.position, Quaternion.AngleAxis(-rayOffset, Enemy.transform.forward) * Enemy.transform.right, rayDistence, 1);//left offset 
        #endregion
        bool raycastcheck = false;
        Debug.Log(raycastcheck);
        //Physics2D.Raycast()
        #region Player Detection Behavior
        if (hit.collider == Player.GetComponent<Collider2D>() || hitL.collider == Player.GetComponent<Collider2D>() || hitR.collider == Player.GetComponent<Collider2D>())
        {
            Debug.Log("GRUNT SAW PLAYER!");
            #region Follow and Shoot
            raycastcheck = true;
            Enemy.transform.LookAt(Player.transform.position);//sets direction 
            Enemy.transform.Rotate(new Vector3(0, -90, 0), Space.Self);//sets rotation
            playerFound = true;//gun object activation
            if (Vector3.Distance(Enemy.transform.position, Player.transform.position) > 2f)//move if distance from target is greater than 1
            {
                transform.Translate(new Vector3((speed * 1.5f) * Time.deltaTime, 0, 0));// sets transform speed
            }
            #endregion
        }
        #endregion
        #region No Player Detection Behavior
        else
        {
          //  if (!centuryMode)
          //  {
                #region Patrol
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
                        curWp++;//change to next way point Transform
                    }
                }
                else
                {
                    curWp = 0;//patrol reset 
                }
          //  }
                #endregion
           // else
          //  {
              //  #region Century Mode
              //  _Time = _Time + Time.deltaTime;//sets time stamp
              //  float phase = Mathf.Sin(_Time / _Period);//creates rotation phase based on period: how many times per minute the object rotates back and forth
                //
              //  transform.rotation = Quaternion.Euler(new Vector3(0, 0, (phase * _Angle) + patrolAngleOffset)); //movement output 
               // #endregion
           // }
        }
        #endregion
    }
    #endregion
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Pbullet")
        {
            Destroy(this.gameObject);
            GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().PlayerScore += 200;
        }
    }
}
