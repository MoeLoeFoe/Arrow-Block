using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineDraw : MonoBehaviour
{

    public static bool loading;

    private LineRenderer line;
    private Vector3 previousPosition;
    private bool doneDrawing = false, startedDrawing = false;
    public bool drawing = false;
    private Vector2 cameraTopRightCorner;

    [SerializeField] private InkBar inkbarScript;

    [SerializeField]private float minDistance = 0.1f;

    private void Start()
    {
        line=GetComponent<LineRenderer>();
        line.positionCount = 1;
        previousPosition = transform.position;

        cameraTopRightCorner = new Vector2(Camera.main.pixelWidth, Camera.main.pixelHeight);
        cameraTopRightCorner = Camera.main.ScreenToWorldPoint(cameraTopRightCorner);
       
    }
    private void Update()
    {
        Vector3 currentPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (!Input.GetMouseButton(0)&&startedDrawing)
        {
            doneDrawing = true;
            drawing = false;
        }
        if(Input.GetMouseButton(0)&&!doneDrawing&&!loading&& currentPosition.y>-cameraTopRightCorner.y/4)
        {
            
            startedDrawing = true;
            
            currentPosition.z = 0f;
            if (Vector3.Distance(currentPosition, previousPosition) > minDistance)
            {
                drawing = true;
                if (previousPosition == transform.position)
                {
                    line.SetPosition(0, currentPosition);
                }
                else
                {
                    line.positionCount++;
                    line.SetPosition(line.positionCount - 1, currentPosition);
                    
                }
                previousPosition = currentPosition;

                

            }
        }

    }

}
