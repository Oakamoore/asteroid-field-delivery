using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillation : MonoBehaviour
{
    private float timePeriod = 2;
    private float height = 3f;

    //Used to offset the time value so that the object always starts at its initial position 
    private float timeSinceStart;

    //Mean position of the object
    private Vector3 pivot;

    private void Start()
    {
        pivot = transform.position;
        height /= 2;
        timeSinceStart = (3 * timePeriod) / 4;
    }

    void Update()
    {
        //Moves the object up and down, the speed of oscillation is determined by the timePeriod
        Vector3 nextPos = transform.position;
        nextPos.y = pivot.y + height + height * Mathf.Sin(((Mathf.PI * 2) / timePeriod) * timeSinceStart);
        timeSinceStart += Time.deltaTime;
        transform.position = nextPos;
    }
}

