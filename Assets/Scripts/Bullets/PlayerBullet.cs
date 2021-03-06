﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour {

    public float speed = 20f;
    public Rigidbody2D rb;
        
    // Use this for initialization
	void Start () {
        rb.velocity = transform.up * speed;
	}

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.gameObject.CompareTag("Enemy"))
        {
            hitInfo.gameObject.GetComponent<EnemyHealth>().HealthDamage();
        }
    }
}
