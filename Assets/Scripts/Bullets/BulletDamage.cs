using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamage : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.gameObject.CompareTag("Player") && hitInfo.gameObject.GetComponent<PlayerHealth>().health > 0)
        {
            hitInfo.gameObject.GetComponent<PlayerHealth>().HealthDamage();
            //Debug.Log(hitInfo.gameObject.GetComponent<PlayerHealth>().health);
        }
    }
}
