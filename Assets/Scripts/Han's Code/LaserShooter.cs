using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserShooter : MonoBehaviour
{
    public GameObject LaserWarningPrefab; // Visual Warning
    public float WarningTime;
    public GameObject LaserPrefab;
    public float LaserLifeTime;
    public GameObject SpawnPoint;

    private void Update()
    {
        // TEMP TEST
        if(Input.GetKeyDown(KeyCode.F))
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        //Instantiate(LaserWarningPrefab, SpawnPoint.transform.position, SpawnPoint.transform.rotation); 

        StartCoroutine(CoFireLaser());
    }

    IEnumerator CoFireLaser()
    {
        GameObject warning = GameObject.Instantiate(LaserWarningPrefab, SpawnPoint.transform.position, SpawnPoint.transform.rotation);
        Debug.Log("Firing Warning");
        yield return new WaitForSeconds(WarningTime);
        Destroy(warning);
        GameObject laser = GameObject.Instantiate(LaserPrefab, SpawnPoint.transform.position, SpawnPoint.transform.rotation);
        Debug.Log("Firing Laser");
        yield return new WaitForSeconds(LaserLifeTime);
        Destroy(laser);
        Debug.Log("Destroy Laser");
    }


}
