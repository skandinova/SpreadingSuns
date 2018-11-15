using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//YouTube referance https://www.youtube.com/watch?v=IgZQjGyB9zg
public class BackgroundScroll : MonoBehaviour {

    public float SpeedScroll;
    Vector2 startPos;

	// Use this for initialization
	void Start () {
        startPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        float newPos = Mathf.Repeat(Time.time * SpeedScroll, 20);
        transform.position = startPos + Vector2.down * newPos;
	}
}
