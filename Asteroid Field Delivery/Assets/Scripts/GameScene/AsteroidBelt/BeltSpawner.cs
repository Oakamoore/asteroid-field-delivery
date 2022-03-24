using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeltSpawner : MonoBehaviour
{
    public GameObject[] cubePrefab;
    private int randomPrefab;

    public int cubeDensity;
    public int seed;
    public float innerRadius;
    public float outerRadius;
    public float height;
    public bool rotatingClockwise;

    public float minOrbitSpeed;
    public float maxOrbitSpeed;
    public float minRotationSpeed;
    public float maxRotationSpeed;

    private Vector3 localPosition;
    private Vector3 worldOffset;
    private Vector3 worldPosition;
    private float randomRadius;
    private float randomRadian;
    private float x;
    private float y;
    private float z;

    private void Start()
    {
        Random.InitState(seed);

        for (int i = 0; i < cubeDensity; i++)
        {
            do
            {
                randomRadius = Random.Range(innerRadius, outerRadius);
                randomRadian = Random.Range(0, (2 * Mathf.PI));

                y = Random.Range(-(height / 2), (height / 2));
                x = randomRadius * Mathf.Cos(randomRadian);
                z = randomRadius * Mathf.Sin(randomRadian);
            }
            //If the z and x coords aren't compatible with the unity engine, keep checking for ones that are 
            while (float.IsNaN(z) && float.IsNaN(x));

            //Translate the object from the world position to the local position
            localPosition = new Vector3(x, y, z);
            worldOffset = transform.rotation * localPosition;
            worldPosition = transform.position + worldOffset;

            randomPrefab = Random.Range(0, 3);

            GameObject asteroid = Instantiate(cubePrefab[randomPrefab], worldPosition, Quaternion.Euler(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360)));

            asteroid.AddComponent<BeltObject>().SetupBeltObject(Random.Range(minOrbitSpeed, maxOrbitSpeed), Random.Range(minRotationSpeed, maxRotationSpeed), gameObject, rotatingClockwise);

            //Parents the asteroid to the object this script is attached to
            asteroid.transform.SetParent(transform);
        }
    }
}
