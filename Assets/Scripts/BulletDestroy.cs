using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestroy : MonoBehaviour {

    public GameObject bombGameObject;
    public GameObject spinGunObject;
    private Bomb bombScript;
    private SpinBullets spinBulletsScript;

    // Use this for initialization
    void Start () {
        bombGameObject = GameObject.FindGameObjectWithTag("Bomb");
        bombScript = bombGameObject.GetComponent<Bomb>();
        spinGunObject = GameObject.FindGameObjectWithTag("SpinGun");
        spinBulletsScript = spinGunObject.GetComponent<SpinBullets>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space) && bombScript.bombInt > 0)
        {
            Destroy(gameObject);
            spinBulletsScript.afterBombBool = true;
            bombScript.bombBool = true;
        }
    }
    //When offscreen, do something
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
