using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBoomerang : MonoBehaviour {
    //Referance https://www.youtube.com/watch?v=kOzhE3_P2Mk && https://www.youtube.com/watch?v=_Z1t7MNk0c4&t=632s
    public float speed = 5.0f;
    public float durationFollow = 3.0f;

    private Transform player;
    private Vector2 target;
    private Rigidbody2D rb2d;
    private bool aquireTarget;

    // Use this for initialization
    void Start()
    {
        aquireTarget = false;
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        //move toward player position
        target = new Vector2(player.position.x, player.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        if(aquireTarget == false)
        {
            transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
        }

        if(transform.position.x == target.x && transform.position.y == target.y)
        {
            AfterFollowPlayer();
        }
    }

    void AfterFollowPlayer()
    {
        if (aquireTarget == false)
        {
            aquireTarget = true;
            target = (player.transform.position - transform.position).normalized * speed;
            rb2d.velocity = new Vector2(target.x, target.y);
        }
    }
}
