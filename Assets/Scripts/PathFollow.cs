using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Code follow on Youtube tutorial (https://www.youtube.com/watch?v=1aBjTa3xQzE&t=223s)
public class PathFollow : MonoBehaviour {

    public int goToPath;
    public EnemyPathway FollowedPathway;
    public float enemySpeed;
    //Use as a trick to make patrol curve to follow in a curve pattern, con/it reduce requirement to reach on point
    public int patrolCycle = -1;
    private float reachDistance = 0f;
    private int currentPathwayID = 0;
    private bool forwardPatrolBool;
    private bool routeZeroBool;
    private float waitSave;
    private float speedSave;

    //Vector2 last_position;
    Vector2 current_position;

	void Start () {
        speedSave = enemySpeed;
        forwardPatrolBool = true;
        //To avoid effect when start (Stuck on loop)
        routeZeroBool = false;
        if (FollowedPathway == null) // Initialize if reference is missing.
        {
            GameObject[] pathHolders = GameObject.FindGameObjectsWithTag("PathHolder");
            foreach (GameObject go in pathHolders)
            {
                EnemyPathway path = go.GetComponent<EnemyPathway>();
                if (path != null && path.pathNum == goToPath)
                {
                    FollowedPathway = path;
                    break;
                }
            }
        }
    }
	
	void Update () {
        float distance = Vector2.Distance(FollowedPathway.nodes[currentPathwayID].transform.position, transform.position);
        transform.position = Vector2.MoveTowards(transform.position, FollowedPathway.nodes[currentPathwayID].transform.position, Time.deltaTime * enemySpeed);

        if(distance <= reachDistance && forwardPatrolBool)
        {
            currentPathwayID++;
        }
        else if (distance <= reachDistance && forwardPatrolBool == false)
        {
            currentPathwayID--;
        }
        if (currentPathwayID >= FollowedPathway.nodes.Count)
        {
            currentPathwayID--;
            forwardPatrolBool = false;
            patrolCycle--;
        }
        if (distance <= reachDistance && currentPathwayID == 0 && routeZeroBool)
        {
            forwardPatrolBool = true;
            routeZeroBool = false;
            patrolCycle--;
        }
        else
        {
            routeZeroBool = true;
        }
        if (patrolCycle == 0)
        {
            Destroy(gameObject);
        }
        else if (patrolCycle <= -1)
        {
            //Debug.Log("Never Destroy");
        }
    }

    //Bad practice of using two detection collide, OnTigger and distance <= reachDistance. Reach distance must be 0f for no possible glitch. Could not find another solution
    void OnTriggerEnter2D(Collider2D other)
    {
        PathNode node = other.gameObject.GetComponent<PathNode>();
        if (node != null 
            && node.numStops == currentPathwayID 
            && node.waitTime > 0)
        {
            //must pass waitSave float to use startCoroutine
            waitSave = node.waitTime;
            StartCoroutine(CoWaitAndDoThing());
        }
    }

    IEnumerator CoWaitAndDoThing()
    {
        enemySpeed = 0f;
        yield return new WaitForSeconds(waitSave);
        enemySpeed = speedSave;
    }
}
