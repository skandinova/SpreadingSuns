using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestroy : MonoBehaviour
{
    public bool isEnemyBullet;

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
