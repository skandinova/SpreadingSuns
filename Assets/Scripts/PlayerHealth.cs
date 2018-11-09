using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

    public int health;
    private AudioSource audioSource;

	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		if (health <= 0)
        {
            Destroy(gameObject);
        }
	}

    public void HealthDamage()
    {
        audioSource.Stop();
        audioSource.Play();
        health -= 1;
    }
}
