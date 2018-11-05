using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLaser : MonoBehaviour {

    public float laserChargeFloat;
    public float laserTransparentFloat;
    public float laserStayFloat;
    public int laserChargeInt;
    public bool laserProgressBool;
    private int laserChargeSave;
    private bool laserBool;

	// Use this for initialization
	void Start () {
        laserBool = false;
        laserProgressBool = false;
        laserChargeSave = laserChargeInt;
	}
	
	// Update is called once per frame
	void Update () {
        if (laserBool)
        {
            this.GetComponent<SpriteRenderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        }
        else if (laserBool == false && laserProgressBool == false)
        {
            this.GetComponent<SpriteRenderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 0f);
        }
        if (Input.GetKeyDown(KeyCode.Space) && laserBool == false && laserProgressBool == false)
        {
            while (laserChargeInt >= 0)
            {
                laserChargeInt -= 1;
                Debug.Log(laserChargeInt);
            }
            laserProgressBool = true;
            this.GetComponent<SpriteRenderer>().material.color = new Color(1.0f, 1.0f, 1.0f, laserTransparentFloat);
            StartCoroutine(LaserShotCoro());
        }
	}

    IEnumerator LaserShotCoro()
    {
        yield return new WaitForSeconds(laserChargeFloat);
        laserBool = true;
        yield return new WaitForSeconds(laserStayFloat);
        laserBool = false;
        laserProgressBool = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Hello Player");
        }
    }
}
