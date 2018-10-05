using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Code follow on Youtube tutorial (https://www.youtube.com/watch?v=1aBjTa3xQzE&t=223s)
public class PathFollow : MonoBehaviour {

    public EnemyPathway EnemyPathwayScript;
    public float enemySpeed;
    //Use as a trick to make patrol curve to follow in a curve pattern, con/it reduce requirement to reach on point
    public float reachDistance = 1.0f;
    public int patrolCycle = 3;
    private int currentPathwayID = 0;
    private bool forwardPatrolBool;
    private bool routeZeroBool;

    //Vector2 last_position;
    Vector2 current_position;
	// Use this for initialization
	void Start () {
        forwardPatrolBool = true;
        //To avoid effect when start (Stuck on loop)
        routeZeroBool = false;
	}
	
	// Update is called once per frame
	void Update () {
        float distance = Vector2.Distance(EnemyPathwayScript.path_objs[currentPathwayID].position, transform.position);
        transform.position = Vector2.MoveTowards(transform.position, EnemyPathwayScript.path_objs[currentPathwayID].position, Time.deltaTime * enemySpeed);

        if(distance <= reachDistance && forwardPatrolBool)
        {
            currentPathwayID++;
        }
        else if (distance <= reachDistance && forwardPatrolBool == false)
        {
            currentPathwayID--;
        }
        if (currentPathwayID >= EnemyPathwayScript.path_objs.Count)
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
        if (patrolCycle <= 0)
        {
            Destroy(gameObject);
        }
        if (EnemyPathwayScript.enemyStops[0] == 1)
        {
            Debug.Log("Wait one second");
        }
    }
}
