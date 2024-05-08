using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineCollider : MonoBehaviour
{
    private EdgeCollider2D edgecoll;
    private LineRenderer lineren;
 
    void Start()
    {
        edgecoll=GetComponent<EdgeCollider2D>();
        lineren=GetComponent<LineRenderer>();  
    }

  
    void Update()
    {
        SetEdgeCollider();
    }
    void SetEdgeCollider()
    {
        List<Vector2> edges=new List<Vector2>();
        for(int point=0;point<lineren.positionCount;point++)
        {
            Vector3 lineRendererPoint = lineren.GetPosition(point);
            edges.Add(new Vector2(lineRendererPoint.x,lineRendererPoint.y));
        }
        edgecoll.SetPoints(edges);
    }
}
