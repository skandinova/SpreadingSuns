using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public int numberOfBombs;
    public AudioClip bombClip;
    private AudioSource audioSource;
    public float stunTime = 3f;

    // Use this for initialization
    void Start ()
    {
        audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TriggerBomb();
        }
	}

    public void TriggerBomb()
    {
        numberOfBombs--;
        Debug.Log("Triggered Bomb! bombCount= " + numberOfBombs);

        DestroyAllEnemyBullets();

        // Stun enemies
        StunAllEnemies();

        // Play Audio Effect
        audioSource.Play();
    }

    public void DestroyAllEnemyBullets()
    {
        BulletDestroy[] enemyBullets = FindObjectsOfType<BulletDestroy>();
        foreach (BulletDestroy bullet in enemyBullets)
        {
            if(bullet.isEnemyBullet)
            {
                bullet.DestroyBullet();
            }
        }
    }

    public void StunAllEnemies()
    {
        EnemyBase[] allEnemies = FindObjectsOfType<EnemyBase>();
        foreach (EnemyBase enemy in allEnemies)
        {
            enemy.Stun(stunTime);
        }
    }
}
