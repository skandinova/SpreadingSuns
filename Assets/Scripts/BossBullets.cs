using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Youtube tutorial (https://www.youtube.com/watch?v=P20DQj1l4jw&t=316s)
public class BossBullets : MonoBehaviour {
    [Header("Projectile Settings")]
    public int numberOfProjectiles;
    public float projectileSpeed;
    public float rotationSpeed;
    public float bulletPerSeconds;
    public GameObject projectilePrefab;
    private float rotationSave;
    private bool reverseBulletBool;
    private bool shotBool;

    [Header("Private Variables")]
    private Vector2 startPoint;
    private const float radius = 1F;
    public float seconds;
    public bool stop;

    void Start () {
<<<<<<< HEAD
        startPoint = transform.position;
        StartCoroutine(SpawnProjectile(numberOfProjectiles));
    }

    // Update is called once per frame
    void Update () {
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
       //     startPoint = transform.position;
         //   SpawnProjectile(numberOfProjectiles);
        //}
=======
        shotBool = false;
        reverseBulletBool = false;
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
>>>>>>> b337113492c09817aba8d64f44f6dedb5b6eec86
    }

    private IEnumerator SpawnProjectile(int _numberOfProjectile)
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

<<<<<<< HEAD
        while (!stop) {
            for (int i = 0; i <= _numberOfProjectile - 1; i++)
            {
                float projectileDirXPosition = startPoint.x + Mathf.Sin((angle * Mathf.PI) / 180) * radius;
                float projectileDirYPosition = startPoint.y + Mathf.Cos((angle * Mathf.PI) / 180) * radius;
=======
        for (int i = 0; i <= _numberOfProjectile -1; i++)
        {
            float projectileDirXPosition = startPoint.x + Mathf.Sin(((angle + rotationSave) * Mathf.PI) / 180) * radius;
            float projectileDirYPosition = startPoint.y + Mathf.Cos(((angle + rotationSave)* Mathf.PI) / 180) * radius;
>>>>>>> b337113492c09817aba8d64f44f6dedb5b6eec86

                Vector2 projectileVector = new Vector2(projectileDirXPosition, projectileDirYPosition);
                Vector2 projectileMoveDirection = (projectileVector - startPoint).normalized * projectileSpeed;

<<<<<<< HEAD
                GameObject tmpObj = Instantiate(projectilePrefab, startPoint, Quaternion.identity);
                tmpObj.GetComponent<Rigidbody2D>().velocity = new Vector2(projectileMoveDirection.x, projectileMoveDirection.y);
                angle += angleStep;
            }
            yield return new WaitForSeconds(seconds);
=======
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
>>>>>>> b337113492c09817aba8d64f44f6dedb5b6eec86
        }
    }

    IEnumerator CoWaitAndDoThing()
    {
        yield return new WaitForSeconds(bulletPerSeconds);
        startPoint = transform.position;
        SpawnProjectile(numberOfProjectiles);
        shotBool = false;
    }
}
