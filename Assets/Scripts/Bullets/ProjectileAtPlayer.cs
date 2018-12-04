using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileAtPlayer : MonoBehaviour {
    //Referance https://www.youtube.com/watch?v=kOzhE3_P2Mk && https://www.youtube.com/watch?v=_Z1t7MNk0c4&t=632s
    public float speed;

    private Transform player;
    private Vector2 target;
    private Rigidbody2D rb2d;

	// Use this for initialization
	void Start () {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        //move toward player position
        target = (player.transform.position - transform.position).normalized * speed;
        rb2d.velocity = new Vector2(target.x, target.y);
        //target = new Vector2(player.position.x, player.position.y);
	}
	
	// Update is called once per frame
	void Update () {
        //transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
	}
}
