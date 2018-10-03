using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {
    public Transform[] pathPoint;
    public float enemyMovement;

    private Rigidbody2D rb2d;
    private int currentPath;
	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position != pathPoint[currentPath].position)
        {
            Vector2 pos = Vector2.MoveTowards(transform.position, pathPoint[currentPath].position, enemyMovement * Time.deltaTime);
            rb2d.MovePosition(pos);
        }
        else
        {
            currentPath = (currentPath + 1) % pathPoint.Length;
        }
	}
}