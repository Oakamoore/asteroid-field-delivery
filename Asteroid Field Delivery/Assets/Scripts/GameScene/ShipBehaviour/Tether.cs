using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tether : MonoBehaviour
{

    public Transform[] links;
    const float distance = 10;

    void Update()
    {
        //All points are equidistant from each other 
        Vector3 prevPoint = transform.position;
        foreach(Transform link in links)
        { 
            Vector3 direction = (prevPoint - link.position).normalized;
            link.position = prevPoint - direction * distance;
            prevPoint = link.position;
        }
    }
}
