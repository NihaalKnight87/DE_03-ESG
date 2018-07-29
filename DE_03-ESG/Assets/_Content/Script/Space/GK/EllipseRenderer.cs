using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class EllipseRenderer : MonoBehaviour {
    
    LineRenderer lr;

    [Range(3, 36)]
    public int Segments;

    public Ellipse ellipse;
    //public float xAxis;
    //public float yAxis;

    private void Awake()
    {
        lr = GetComponent<LineRenderer>();
        CalculateEllipse();
    }

    void CalculateEllipse()
    {
        Vector3[] points = new Vector3[Segments + 1];
        //for (int i = 0; i < Segments; i++);
        for (int i = 0; i < Segments; i++)
        {

            //float angle = ((float)i/ (float)Segments) * 360 * Mathf.Deg2Rad;
            //float x = Mathf.Sin(angle) * xAxis;
            //float y = Mathf.Cos(angle) * yAxis;
            Vector2 postion2D = ellipse.Evaluate((float)i / (float)Segments);

            //points[i] = new Vector3(x, y, 0f);
            points[i] = new Vector3(postion2D.x, postion2D.y, 0f);


         }
        points[Segments] = points[0];
        
        lr.positionCount = Segments + 1;
        lr.SetPositions (points);

    }

    private void OnValidate()
    {
        if (Application.isPlaying && lr != null)
        {
            CalculateEllipse();
        }
    }


    



}
