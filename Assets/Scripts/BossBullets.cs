using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Youtube tutorial (https://www.youtube.com/watch?v=P20DQj1l4jw&t=316s)
public class BossBullets : MonoBehaviour {
    [Header("Projectile Settings")]
    public int numberOfProjectiles;
    public float projectileSpeed;
    public GameObject projectilePrefab;

    [Header("Private Variables")]
    private Vector2 startPoint;
    private const float radius = 1F;
    public float seconds;
    public bool stop;

    void Start () {
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
    }

    private IEnumerator SpawnProjectile(int _numberOfProjectile)
    {
        float angleStep = 360f / _numberOfProjectile;
        float angle = 0f;

        while (!stop) {
            for (int i = 0; i <= _numberOfProjectile - 1; i++)
            {
                float projectileDirXPosition = startPoint.x + Mathf.Sin((angle * Mathf.PI) / 180) * radius;
                float projectileDirYPosition = startPoint.y + Mathf.Cos((angle * Mathf.PI) / 180) * radius;

                Vector2 projectileVector = new Vector2(projectileDirXPosition, projectileDirYPosition);
                Vector2 projectileMoveDirection = (projectileVector - startPoint).normalized * projectileSpeed;

                GameObject tmpObj = Instantiate(projectilePrefab, startPoint, Quaternion.identity);
                tmpObj.GetComponent<Rigidbody2D>().velocity = new Vector2(projectileMoveDirection.x, projectileMoveDirection.y);
                angle += angleStep;
            }
            yield return new WaitForSeconds(seconds);
        }
    }
}
