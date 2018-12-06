using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerifyWaveClearance : MonoBehaviour {

    [System.Serializable]
    public class NextWave
    {
        public GameObject spawnWaves;
    }
    public NextWave[] nextWaves;

    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
