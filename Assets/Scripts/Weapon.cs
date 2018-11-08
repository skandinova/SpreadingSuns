using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {
    // Use this for initialization
    public float fireRate;
    public Transform firePoint;
    public GameObject bulletPrefab;
    private bool isShooting;

    private void Start()
    {
        isShooting = false;
    }
    // Update is called once per frame
    void Update () {
        if (Input.GetButton("Fire1") && isShooting == false)
        {
            StartCoroutine(FireRateCoro());
            isShooting = true;
            //shoot();
        }
	}

    //void shoot()
    //{
    //    Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    //}

    IEnumerator FireRateCoro()
    {
        yield return new WaitForSeconds(fireRate);
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        isShooting = false;
    }
}
