using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {

    public int health;
    public AudioSource audioHit;
    public AudioSource audioDeath;
    private bool canhit;
    public MonoBehaviour movmeent;
    // Use this for initialization
    void Start () {
        canhit = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (health <= 0)
        {
            if (audioDeath != null)
            {
                audioDeath.Play();
            }
            Invoke("gameends", 1f);
            movmeent.enabled = false;
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
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy" && canhit == true)
        {
            canhit = false;
            health = health - 1;
            Invoke("goback", 1f);
        }

    }
    public void goback()
    {
        canhit = true;
    }
    public void gameends()
    {
        LoadSceneTrigger.LoadGameOverMenuScene(Application.loadedLevel);
    }
}
