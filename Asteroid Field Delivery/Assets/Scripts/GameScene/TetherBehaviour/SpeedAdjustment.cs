using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedAdjustment : MonoBehaviour
{
    public bool boulderOneAttached = false;
    public bool boulderTwoAttached = false;
    public bool boulderThreeAttached = false;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Boulder1")
        {
            boulderOneAttached = true;
        }

        if (collision.gameObject.name == "Boulder2")
        {
            boulderTwoAttached = true;
        }

        if (collision.gameObject.name == "Boulder3")
        {
            boulderThreeAttached = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "Boulder1")
        {
            boulderOneAttached = false;
        }

        if (collision.gameObject.name == "Boulder2")
        {
            boulderTwoAttached = false;
        }

        if (collision.gameObject.name == "Boulder3")
        {
            boulderThreeAttached = false;
        }
    }

}
