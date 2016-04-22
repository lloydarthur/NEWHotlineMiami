using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BossBaseMovement : MonoBehaviour {
 
    public GameObject Player = null;//player ref
    public GameObject Enemy;//gameobject Ref
    public Transform[] wayPoints;//waypoint array, dydnamic size based 
    //public Vector3 intPlayerpos;//intial postion check for debugging 
    int curWp;
    public int speed;
    public float bossHealth;
    bool isDieing;

    IEnumerator takeCover()
    {
        isDieing = true;
        GameObject.FindGameObjectWithTag("bossGun").GetComponent<Bosssprite>().playerFound = false;
        yield return new WaitForSeconds(10);
        isDieing = false;
        GameObject.FindGameObjectWithTag("bossGun").GetComponent<Bosssprite>().playerFound = true; ;
        
    }
    
    void Start()
    {
        Enemy = this.gameObject;//enemy intialization
        Player = GameObject.FindGameObjectWithTag("Player");//player intialization 
    }
    void FixedUpdate()
    {
        Gen_movment();
        if(bossHealth<10&&bossHealth>1)
        {
            StartCoroutine(takeCover());
        }
        else if(bossHealth>10)
        {
            isDieing = false;
        }
        else if(bossHealth<=0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
	void Gen_movment()
    {
        if (!isDieing)
        {
            if (curWp < wayPoints.Length)//checks progress of patrol
            {
                //playerFound = false;//gun object de-activation
                Enemy.transform.LookAt(wayPoints[curWp].position);//sets direction
                Enemy.transform.Rotate(new Vector3(0, -90, 0), Space.Self);//sets rotation of game object 
                if (Vector3.Distance(Enemy.transform.position, wayPoints[curWp].position) > 1f)//move if distance from target is greater than 1
                {
                    transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));// sets transform speed
                }
                else if (Vector3.Distance(Enemy.transform.position, wayPoints[curWp].position) <= 1f)// if way point is within a distence of 1
                {
                    //StartCoroutine(CenturyMode());
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
            
            //playerFound = false;//gun object de-activation
            Enemy.transform.LookAt(wayPoints[0].position);//sets direction
            Enemy.transform.Rotate(new Vector3(0, -90, 0), Space.Self);//sets rotation of game object 
            if (Vector3.Distance(Enemy.transform.position, wayPoints[curWp].position) > 1f)//move if distance from target is greater than 1
            {
                transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));// sets transform speed
            }
            else
            {

            } 
            bossHealth += .1f;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag=="Pbullet")
        {
            bossHealth -= 1;
            if(bossHealth<=0)
            {
                Destroy(this.gameObject);
               
            }
        }
    }
}
