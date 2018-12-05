using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLaser : MonoBehaviour {

    public float laserChargeFloat;
    public float laserTransparentFloat;
    public float laserStayFloat;
    public bool isLaserProgress;
    private bool isShooting;
    private bool isHit;
    private AudioSource audioSource;
	// Use this for initialization
	void Start () {
        isShooting = false;
        isLaserProgress = false;
        isHit = false;
        audioSource = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        if (isShooting)
        {
            this.GetComponent<SpriteRenderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        }
        else if (isShooting == false && isLaserProgress == false)
        {
            this.GetComponent<SpriteRenderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 0f);
        }
        if (Input.GetKeyDown(KeyCode.Space) && isShooting == false && isLaserProgress == false)
        {
            isLaserProgress = true;
            this.GetComponent<SpriteRenderer>().material.color = new Color(1.0f, 1.0f, 1.0f, laserTransparentFloat);
            StartCoroutine(LaserShotCoro());
        }
	}

    IEnumerator LaserShotCoro()
    {
        yield return new WaitForSeconds(laserChargeFloat);
        isShooting = true;
        audioSource.Play();
        yield return new WaitForSeconds(laserStayFloat);
        isShooting = false;
        isLaserProgress = false;
        isHit = false;

        //Stopping audio
        audioSource.Stop();
    }

    //A bug if the player stay completely still, the tigger would not be detected
    private void OnTriggerStay2D(Collider2D other)
    {
        //Used to detect if player is collide and hit yet
        if (other.gameObject.CompareTag("Player") && isShooting && isHit == false)
        {
            //reverse bool
            isHit = !isHit;
            //Player Health Script to decrease health
            other.GetComponent<PlayerHealth>().HealthDamage();
            Debug.Log("BulletLaser damage");
        }
    }
}
