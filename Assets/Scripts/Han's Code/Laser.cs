using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lazer : MonoBehaviour

{
    public GameObject LaserWarning;
    public GameObject Laser;
    public GameObject SpawnPoint;
    private void Start()
    {
        Instantiate(LaserWarning, SpawnPoint.position, SpawnPoint.rotation); 
    }

}
