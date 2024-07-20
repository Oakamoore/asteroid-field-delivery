using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{

    Rigidbody rb;

    public float speed;
    private float initialSpeed;

    public GameObject fourthPoint;
    public SpeedAdjustment sdScript;


    void Start()
    {

        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeAll;

        initialSpeed = speed;

        //Used to adjust the speed of the ship, depending on what boulder it's carrying
        fourthPoint = GameObject.Find("FourthPoint");

        sdScript = fourthPoint.GetComponent<SpeedAdjustment>();

    }

    void FixedUpdate()
    {
        UpdateMovement();
    }

    void UpdateMovement()
    {
        //Changes the movement speed of the ship, depending on what boulder it's carrying
        if (sdScript.boulderOneAttached == true)
        {
            speed = initialSpeed / 2.5f;
        }
        else if (sdScript.boulderTwoAttached == true)
        {
            speed = initialSpeed / 2f;
        }
        else if (sdScript.boulderThreeAttached == true)
        {
            speed = initialSpeed / 1.7f;
        }
        else
        {
            speed = initialSpeed;
        }

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            //Unfreezes constraints on click, allows for upwards and sideways movement
            rb.constraints &= ~RigidbodyConstraints.FreezePositionX;
            rb.constraints &= ~RigidbodyConstraints.FreezePositionY;

            if (rb.velocity.y < speed)
            {
                rb.AddForce(rb.transform.up * speed / 2, ForceMode.VelocityChange);
            }
        }

        //When the key is no longer being held, and opposite and equal force is added to the ship, to stop it upwards
        if (!Input.GetKey(KeyCode.W) || !Input.GetKey(KeyCode.UpArrow))
        {
            if (rb.velocity.y > 0f)
            {
                rb.AddForce(rb.transform.up * -rb.velocity.y, ForceMode.VelocityChange);
            }
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            //Unfreezes constraints on click, allows for upwards and sideways movement
            rb.constraints &= ~RigidbodyConstraints.FreezePositionX;
            rb.constraints &= ~RigidbodyConstraints.FreezePositionY;

            if (rb.velocity.x < speed)
            {
                rb.AddForce(-rb.transform.right * speed / 10, ForceMode.VelocityChange);
            }
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            //Unfreezes constraints on click, allows for upwards and sideways movement
            rb.constraints &= ~RigidbodyConstraints.FreezePositionX;
            rb.constraints &= ~RigidbodyConstraints.FreezePositionY;

            if (rb.velocity.x < speed)
            {
                rb.AddForce(rb.transform.right * speed, ForceMode.VelocityChange);
            }
        }

        //When the key is no longer being held, and opposite and equal force is added to the ship, to stop it drifting backwards
        if (!Input.GetKey(KeyCode.D) || !Input.GetKey(KeyCode.RightArrow))
        {
            if (rb.velocity.x > 0f)
            {
                rb.AddForce(-rb.transform.right * rb.velocity.x, ForceMode.VelocityChange);
            }
        }

        //Clamping speed 
        if (rb.velocity.x > speed)
        {
            rb.AddForce(rb.transform.right * -(rb.velocity.x - speed), ForceMode.VelocityChange);
        }

        if (rb.velocity.x < speed)
        {
            rb.AddForce(rb.transform.forward * -(rb.velocity.x + speed), ForceMode.VelocityChange);
        }

    }

}
