using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectBehaviour : MonoBehaviour
{

    GameObject asteroid;

    void Update()
    {
        asteroid = FieldSpawner.SharedInstance.GetObject();
        if (asteroid != null)
        {
            asteroid.transform.localScale = transform.localScale * Random.Range(5f, 8f);

            //Checks if the asteroid has a mesh collider, if it doesn't it adds one to it
            if (asteroid.GetComponent<MeshCollider>() == null)
            {
                MeshCollider mc = asteroid.AddComponent<MeshCollider>();
                mc.convex = true;
            }

            //Checks if the asteroid has a rigidbody, if it doesn't it adds one to it
            if (asteroid.GetComponent<Rigidbody>() == null)
            {
                Rigidbody rb = asteroid.AddComponent<Rigidbody>();
                rb.useGravity = false;
                //Ensures the asteroids don't move off the Z line
                rb.constraints = RigidbodyConstraints.FreezePositionZ;
            }

            asteroid.AddComponent<MovementAndRotation>();
            asteroid.SetActive(true);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
            Debug.Log("COLLIDED!!!!");
    } 

}
