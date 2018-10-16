using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineExample : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
        StartCoroutine(CoWaitAndDoThing());
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    IEnumerator CoWaitAndDoThing()
    {
        Debug.Log("Do Thing A");
        yield return new WaitForSeconds(1f);
        Debug.Log("Do Thing B");
        float duration = 5f;
        float timer = 0f;
        while(timer < duration)
        {
            timer += Time.deltaTime;

            // Stop execution, wait for update, then resume.
            yield return null;
        }
    }

}
