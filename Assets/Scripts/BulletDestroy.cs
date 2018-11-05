using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestroy : MonoBehaviour
{
    public bool isEnemyBullet;

 //   public GameObject bombGameObject;
 //   public GameObject spinGunObject;
 //   private Bomb bombScript;
 //   private SpinBullets spinBulletsScript;

 //   // Use this for initialization
 //   void Start () {
 //       bombGameObject = GameObject.FindGameObjectWithTag("Bomb");
 //       bombScript = bombGameObject.GetComponent<Bomb>();
 //       spinGunObject = GameObject.FindGameObjectWithTag("SpinGun");
 //       spinBulletsScript = spinGunObject.GetComponent<SpinBullets>();
 //   }
	
	//// Update is called once per frame
	//void Update ()
 //   {
 //       // Player fired a bomb
 //       if (Input.GetKeyDown(KeyCode.Space) && bombScript.numberOfBombs > 0)
 //       {
 //           Destroy(gameObject);
 //           spinBulletsScript.afterBombBool = true;
 //           bombScript.isActivated = true;
 //       }
 //   }

    public void DestroyBullet()
    {
        Destroy(gameObject);
    }

    //When offscreen, do something
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
