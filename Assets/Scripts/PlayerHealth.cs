using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

    public int health;
    public AudioSource audioHit;
    public AudioSource audioExplode;

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (health <= 0)
        {
            audioExplode.Play();
            Application.LoadLevel(Application.loadedLevel);
        }
	}

    public void HealthDamage()
    {
        audioHit.Stop();
        health -= 1;
        audioHit.Play();
    }
}
