using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Base class for all enemy types.
/// 
/// Michael Wolf
/// </summary>
public abstract class EnemyBase : MonoBehaviour
{
    protected bool canShoot = true;

    // Stops all shooting for a set amount of time.
    public virtual void Stun(float stunDuration)
    {
        //Debug.Log("Enemy Stunned! " + gameObject.name);
        StartCoroutine(CoWaitForStun(stunDuration));
    }

    protected IEnumerator CoWaitForStun(float stunDuration)
    {
        canShoot = false;
        yield return new WaitForSeconds(stunDuration);
        canShoot = true;
    }

}
