using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinePath : MonoBehaviour
{
    
    private void Update()
    {
        // TEMP TEST
        if (Input.GetKeyDown(KeyCode.F))
        {
            Shoot();
        }
    }


    public float MoveSpeed = 5.0f;

    public float frequency = 20.0f;  // Speed of sine movement
    public float magnitude = 0.5f;   // Size of sine movement
    private Vector2 axis;

    private Vector2 pos;

    public void Shoot()
    {
        pos = transform.position;
        Destroy(Shoot);
        axis = transform.right;  // May or may not be the axis you want

    }

    void Update()
    {
        pos += (Vector2)transform.up * Time.deltaTime * MoveSpeed;
        transform.position = pos + axis * Mathf.Sin(Time.time * frequency) * magnitude;
    }
}