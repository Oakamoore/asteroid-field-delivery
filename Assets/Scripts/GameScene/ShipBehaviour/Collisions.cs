using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collisions : MonoBehaviour
{
    public bool hasCollided = false;

    private void OnCollisionEnter(Collision collision)
    {
        //Checks to see if the ship has collided with any obstacles 
        if(collision.gameObject.name == "asteroid1(Clone)" || collision.gameObject.name == "asteroid2(Clone)" || collision.gameObject.name == "asteroid3(Clone)")
        {
            hasCollided = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        //Checks to see if the ship has stopped colliding with any obstacles 
        if (collision.gameObject.name == "asteroid1(Clone)" || collision.gameObject.name == "asteroid2(Clone)" || collision.gameObject.name == "asteroid3(Clone)")
        {
            hasCollided = false;
        }
    }

}
