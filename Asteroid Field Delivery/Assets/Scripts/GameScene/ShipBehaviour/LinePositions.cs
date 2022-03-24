using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinePositions : MonoBehaviour
{

    public LineRenderer line;
    public Transform[] linePos;

    
    void Start()
    {
        //The number of points in the line are equal to the number of elements in array of transforms
        line.positionCount = linePos.Length;
    }

    void Update()
    {
        //The position of a point in the line renderer is equal to the position of one of the elements in the array of transforms
        for(int i = 0; i < linePos.Length; i++)
        {
            line.SetPosition(i, linePos[i].position);
        }
    }
}
