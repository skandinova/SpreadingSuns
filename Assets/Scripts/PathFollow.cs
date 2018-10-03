using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFollow : MonoBehaviour {

    public EnemyPathway EnemyPathwayScript;
    public int currentPathwayID = 0;
    public float enemySpeed;
    public float rotationSpeed = 5.0f;
    public string pathName;
    private float reachDistance = 1.0f;

    Vector2 last_position;
    Vector2 current_position;
	// Use this for initialization
	void Start () {
        //EnemyPathwayScript = GameObject.Find(pathName).GetComponent<EnemyPathway>();
        last_position = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        float distance = Vector2.Distance(EnemyPathwayScript.path_objs[currentPathwayID].position, transform.position);
        transform.position = Vector2.MoveTowards(transform.position, EnemyPathwayScript.path_objs[currentPathwayID].position, Time.deltaTime * enemySpeed);

        if(distance <= reachDistance)
        {
            currentPathwayID++;
        }
	}
}
