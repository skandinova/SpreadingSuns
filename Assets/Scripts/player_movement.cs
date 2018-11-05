using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_movement : MonoBehaviour {
    public float movement;
    public float slow;
    private Rigidbody2D myRigidBody;

	// Use this for initialization
	void Start () {
        
        myRigidBody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        float horizontal = Input.GetAxis("Horizontal") * movement;
        float vertical = Input.GetAxis("Vertical") * movement;

        HandleMovement(horizontal, vertical);
	}

    private void HandleMovement(float horizontal, float vertical)
    {
        myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, vertical);
        myRigidBody.velocity = new Vector2(horizontal, myRigidBody.velocity.y);
    }
}
