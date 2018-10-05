using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Code follow on Youtube tutorial (https://www.youtube.com/watch?v=1aBjTa3xQzE&t=223s)
public class EnemyPathway : MonoBehaviour {

    public Color rayColor = Color.white;
    public List<Transform> path_objs = new List<Transform>();
    Transform[] theArray;
    public List<int> enemyStops = new List<int>();

    void OnDrawGizmos()
    {
        Gizmos.color = rayColor;
        theArray = GetComponentsInChildren<Transform>();
        path_objs.Clear();

        foreach (Transform path_obj in theArray)
        {
            if (path_obj != this.transform)
            {
                path_objs.Add(path_obj);
            }

            for(int i = 0; i < path_objs.Count; i++)
            {
                Vector2 position = path_objs[i].position;
                if (i > 0)
                {
                    Vector2 previous = path_objs[i - 1].position;
                    Gizmos.DrawLine(previous, position);
                    Gizmos.DrawWireSphere(position, 0.3f);
                }
            }
        }
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
