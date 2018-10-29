using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Youtube tutorial (https://www.youtube.com/watch?v=P20DQj1l4jw&t=316s)
public class SpinBullets : MonoBehaviour {
    [Header("Projectile Settings")]
    public int numberOfProjectiles;
    public float projectileSpeed;
    public float rotationSpeed;
    public float bulletPerSeconds;
    public float afterBombTime;
    public float rotationSave;
    public GameObject projectilePrefab;
    public bool reverseBulletBool;
    public bool afterBombBool;

    [Header("Private Variables")]
    private Vector2 startPoint;
    private bool shotBool;
    private float afterBombSave;
    private const float radius = 1F;

    void Start () {
        shotBool = false;
        reverseBulletBool = false;
        afterBombSave = afterBombTime;
        afterBombBool = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (shotBool == false)
        {
            shotBool = true;
            StartCoroutine(CoWaitAndDoThing());
        }

        if (Input.GetKeyDown("space") && reverseBulletBool == false)
        {
            reverseBulletBool = true;
        }
        else if (Input.GetKeyDown("space") && reverseBulletBool)
        {
            reverseBulletBool = false;
        }
    }

    private void SpawnProjectile(int _numberOfProjectile)
    {
        float angleStep = 360f / _numberOfProjectile;
        float angle = 0f;
        //Used to save rotation location and add into angle for rotation effect
        if (reverseBulletBool == false)
        {
            rotationSave += rotationSpeed;
        }
        else if (reverseBulletBool)
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

    IEnumerator CoWaitAndDoThing()
    {
        if (afterBombBool == false)
        {
            yield return new WaitForSeconds(bulletPerSeconds);
            startPoint = transform.position;
            SpawnProjectile(numberOfProjectiles);
            shotBool = false;
        }
        else if (afterBombBool)
        {
            yield return new WaitForSeconds(afterBombSave);
            afterBombBool = false;
            shotBool = false;
        }
    }
}
