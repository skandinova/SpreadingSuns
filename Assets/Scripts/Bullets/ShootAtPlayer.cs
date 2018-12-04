using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootAtPlayer : MonoBehaviour {
    //Referance https://www.youtube.com/watch?v=_Z1t7MNk0c4&t=632s

    public float fireRate;
    public Transform firePoint;
    public GameObject bulletPrefab;
    private bool isShooting;

    // Use this for initialization
    void Start () {
        isShooting = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (isShooting == false)
        {
            StartCoroutine(FireRateCoro());
            isShooting = true;
        }
    }

    IEnumerator FireRateCoro()
    {
        yield return new WaitForSeconds(fireRate);
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        isShooting = false;
    }
}
