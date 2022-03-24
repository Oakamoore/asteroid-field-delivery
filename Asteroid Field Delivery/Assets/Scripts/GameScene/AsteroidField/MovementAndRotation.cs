using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementAndRotation : MonoBehaviour
{
    private float timePeriod = 2;
    private float height = 6f;

    //Used to offset the time value so that the object always starts at its initial position 
    private float timeSinceStart;

    //Mean position of the object
    private Vector3 pivot;

    private Vector3 rotation;
    private float rotationSpeed = 5;

    private void Start()
    {
        pivot = transform.position;
        height /= 2;
        timeSinceStart = (3 * timePeriod) / 4;

        rotation.y = Random.Range(1, 5);
        rotation.x = Random.Range(1, 5);
        rotation.z = Random.Range(1, 5);
    }



    void Update()
    {
        //Moves the object up and down, the speed of oscillation is determined by the timePeriod
        Vector3 nextPos = transform.position;
        nextPos.y = pivot.y + height + height * Mathf.Sin(((Mathf.PI * 2) / timePeriod) * timeSinceStart);
        timeSinceStart += Time.deltaTime;
        transform.position = nextPos;

        //Randomly rotates the object
        transform.Rotate(rotation * rotationSpeed * Time.deltaTime);
    }
}
