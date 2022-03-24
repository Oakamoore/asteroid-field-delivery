using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachAndDetach : MonoBehaviour
{
    GameObject fourthPoint;
    GameObject firstLanding;
    Rigidbody rb;
    
    //Prevents the player from picking up a boulder more than once
    int interactCount = 1;

    private void Start()
    {
        fourthPoint = GameObject.Find("FourthPoint");
        firstLanding = GameObject.Find("Landing");
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        /*Makes the boulder a child of the tether, if the boulder collides with the last point in the tether
         and the boulder hasn't collided with the tether previously, and the tether doesn't have any current children*/
        if (collision.gameObject == fourthPoint && interactCount == 1 && fourthPoint.transform.childCount == 0)
        {
            this.transform.parent = fourthPoint.transform;
            interactCount--;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        /*On collision with the other planet, the boulder is removed as a child of the tether,
         and its rigid body constraints are frozen*/
        if(other.gameObject == firstLanding)
        {
            this.transform.parent = null;
            rb.constraints = RigidbodyConstraints.FreezeAll;
        }
    }

}
