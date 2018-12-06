using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

    public int health;
    public AudioSource audioDeath;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (health <= 0)
        {
            if (audioDeath != null)
            {
                audioDeath.Play();
            }
            Destroy(gameObject);
        }
	}

    public void HealthDamage()
    {
        health -= 1;
    }
}
