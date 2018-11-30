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
            if (audioExplode != null)
            {
                audioExplode.Play();
            }
            Application.LoadLevel(Application.loadedLevel);
        }
	}

    public void HealthDamage()
    {
        if (audioHit != null)
        {
            audioHit.Stop();
            audioHit.Play();
        }
        health -= 1;
    }
}
