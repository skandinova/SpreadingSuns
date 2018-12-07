using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_movement : MonoBehaviour {
    //public float movement;
    public float slow;
    private Rigidbody2D myRigidBody;
    public float speed = 1f;
	// Use this for initialization
	void Start () {
        
        myRigidBody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        HandleMovement(horizontal, vertical);
	}

    private void HandleMovement(float horizontal, float vertical)
    {
        if (!Input.GetKey(KeyCode.LeftShift))
        {
            transform.position += new Vector3(horizontal * speed, vertical * speed, transform.position.z);
        }
        else
        {
            transform.position += new Vector3(horizontal * slow, vertical * slow, transform.position.z);
        }
        //myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, vertical);
        //myRigidBody.velocity = new Vector2(horizontal, myRigidBody.velocity.y);
    }
}
