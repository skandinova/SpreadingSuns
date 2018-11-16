using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Code follow on Youtube tutorial (https://www.youtube.com/watch?v=1aBjTa3xQzE&t=223s)
public class EnemyPathway : MonoBehaviour {

    public int pathNum;
    public Color rayColor = Color.white;
    public List<PathNode> nodes = new List<PathNode>();
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
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
