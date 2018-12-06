using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {

    public int health;
    public float damageColor = 1f;
    public AudioSource audioHit;
    public AudioSource audioDeath;
    private bool canhit;
    public MonoBehaviour movmeent;
    private Renderer renderer;

    [SerializeField]
    private Color colorToTurnTo = Color.white;

    // Use this for initialization
    void Start () {
        canhit = true;
        renderer = GetComponent<Renderer>();
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
            audioHit.Play();
        }
        health -= 1;
        StartCoroutine(ColorChangeCoro());
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy" && canhit == true)
        {
            canhit = false;
            health = health - 1;
            Invoke("goback", 1f);
            if (audioHit != null)
            {
                audioHit.Play();
            }
            StartCoroutine(ColorChangeCoro());
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

    IEnumerator ColorChangeCoro()
    {
        renderer.material.color = colorToTurnTo;
        yield return new WaitForSeconds(damageColor);
        colorToTurnTo = Color.white;
        renderer.material.color = colorToTurnTo;
    }
}
