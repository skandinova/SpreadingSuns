﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Code follow on Youtube tutorial (https://www.youtube.com/watch?v=1aBjTa3xQzE&t=223s)
public class EnemyPathway : MonoBehaviour {

    public Color rayColor = Color.white;
    //public List<Transform> path_objs = new List<Transform>();
    public List<PathNode> nodes = new List<PathNode>();
    //public List<float> enemyStops = new List<float>();
    PathNode[] theArray;

    void OnDrawGizmos()
    {
        Gizmos.color = rayColor;
        theArray = GetComponentsInChildren<PathNode>();
        nodes.Clear();

        foreach (PathNode node in theArray)
        {
            if (node != this.transform)
            {
                nodes.Add(node);
            }

        }
        for (int i = 0; i < nodes.Count; i++)
        {
            Vector2 position = nodes[i].transform.position;
            if (i > 0)
            {
                Vector2 previous = nodes[i - 1].transform.position;
                Gizmos.DrawLine(previous, position);
                Gizmos.DrawWireSphere(position, 0.3f);
            }
        }
        //foreach (Transform path_obj in theArray)
        //{
        //    if (path_obj != this.transform)
        //    {
        //        path_objs.Add(path_obj);
        //    }

        //    for(int i = 0; i < path_objs.Count; i++)
        //    {
        //        Vector2 position = path_objs[i].position;
        //        if (i > 0)
        //        {
        //            Vector2 previous = path_objs[i - 1].position;
        //            Gizmos.DrawLine(previous, position);
        //            Gizmos.DrawWireSphere(position, 0.3f);
        //        }
        //    }
        //}
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}