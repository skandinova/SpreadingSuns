using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasWarning : MonoBehaviour {

    public GameObject laserObject;
    public bool laserWarning;
    private BulletLaser BulletLaserScript;
	// Use this for initialization
	void Start () {
        laserObject = GameObject.FindGameObjectWithTag("LaserBullet");
        BulletLaserScript = laserObject.GetComponent<BulletLaser>();
    }
	
	// Update is called once per frame
	void Update () {
		if (BulletLaserScript.laserProgressBool)
        {
            //this.GetComponent<CanvasRenderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        }
        else if (BulletLaserScript.laserProgressBool == false)
        {
            this.GetComponent<CanvasGroup>().alpha = 0;
        }
	}
}
