using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Youtube tutorial (https://www.youtube.com/watch?v=P20DQj1l4jw&t=316s)
public class SpinningShooterEnemy : EnemyBase
{
    [Header("Projectile Settings")]
    public int numberOfProjectiles;
    public float projectileSpeed;
    public float rotationSpeed;
    public float bulletPerSeconds;
    public float afterBombTime;
    public float rotationSave;
    public GameObject projectilePrefab;
    public bool isReversed;
    //public bool afterBombBool;

    [Header("Private Variables")]
    private Vector2 startPoint;
    private bool isShooting;
    private float afterBombSave;
    private const float radius = 1F;

    void Start () {
        isShooting = false;
        isReversed = false;
        afterBombSave = afterBombTime;
    }
    private void OnEnable()
    {
        StartCoroutine(CoShootCycle());
    }

    // Update is called once per frame
    void Update ()
    {
        if(Input.GetKeyDown("space"))
        {
            isReversed = !isReversed;
        }
        
    }

    private void SpawnProjectile(int _numberOfProjectile)
    {
        float angleStep = 360f / _numberOfProjectile;
        float angle = 0f;
        //Used to save rotation location and add into angle for rotation effect
        if (isReversed == false)
        {
            rotationSave += rotationSpeed;
        }
        else if (isReversed)
        {
            rotationSave -= rotationSpeed;
        }
        for (int i = 0; i <= _numberOfProjectile -1; i++)
        {
            float projectileDirXPosition = startPoint.x + Mathf.Sin(((angle + rotationSave) * Mathf.PI) / 180) * radius;
            float projectileDirYPosition = startPoint.y + Mathf.Cos(((angle + rotationSave)* Mathf.PI) / 180) * radius;

            Vector2 projectileVector = new Vector2(projectileDirXPosition, projectileDirYPosition);
            Vector2 projectileMoveDirection = (projectileVector - startPoint).normalized * projectileSpeed;

            GameObject tmpObj = Instantiate(projectilePrefab, startPoint, Quaternion.identity);
            tmpObj.GetComponent<Rigidbody2D>().velocity = new Vector2(projectileMoveDirection.x, projectileMoveDirection.y);
            angle += angleStep;

            if (rotationSave >= 360f)
            {
                rotationSave -= 360f;
            }
            else if (rotationSave <= -360)
            {
                rotationSave += 360f;
            }
        }
    }

    IEnumerator CoShootCycle()
    {
        Debug.Log("Starting Shoot Cycle");
        while(this.enabled)
        {
            if(canShoot)
            {
                startPoint = transform.position;
                SpawnProjectile(numberOfProjectiles);
                yield return new WaitForSeconds(bulletPerSeconds);
            }
            else
            {
                Debug.Log("Is Stunned...");
                yield return null; // Dont do anything if it cant shoot.
            }

        }
    }

    public override void Stun(float stunDuration)
    {
        base.Stun(stunDuration);
        //Debug.Log("Stunned Spinning Shooter!");
    }
}
