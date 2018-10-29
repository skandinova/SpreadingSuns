using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour {

    public int bombInt;
    public bool bombBool;

    // Use this for initialization
    void Start () {
        bombBool = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (bombBool)
        {
            bombBool = false;
            bombInt--;
        }
	}
}
