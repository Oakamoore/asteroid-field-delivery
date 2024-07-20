using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShipPower : MonoBehaviour
{

    public float maxPower = 1000;
    public float currentPower;

    public PowerBar powerBar;

    private float elapsed = 0f;

    public GameObject fourthPoint;
    public SpeedAdjustment sdScript;

    public GameObject ship;
    public Collisions collisions;

    public Animator anim;
    public float gameTransitionTime = 5f;

    void Start()
    {
        currentPower = maxPower;
        powerBar.setMaxPower(maxPower);

        fourthPoint = GameObject.Find("FourthPoint");

        sdScript = fourthPoint.GetComponent<SpeedAdjustment>();

        ship = GameObject.Find("Ship");

        collisions = ship.GetComponent<Collisions>();
    }

    void Update()
    {
        elapsed += Time.deltaTime;

        //Runs a check every second - 1 unit of power is lost every second if the some of the conditions below are true
        if (elapsed >= 1f)
        {
            //If the ship is moving 
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                losePower(0.5f);
            }

            //If the ship is moving and is carrying the first boulder
            if(sdScript.boulderOneAttached && (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)))
            {
                losePower(1.5f);
            }

            //If the ship is moving and is carrying the second boulder
            if (sdScript.boulderTwoAttached && (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)))
            {
                losePower(1f);
            }

            //If the ship is moving and is carrying the third boulder
            if (sdScript.boulderThreeAttached && (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)))
            {
                losePower(0.7f);
            }

            //If the ship collides with any obstacles when it's not moving, it loses power
            if(collisions.hasCollided == true)
            {
                losePower(3);
            }

            //If the ship collides with any obstacles it loses power
            if (collisions.hasCollided == true && (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)))
            {
                losePower(3);
            }

            //If the ship collides with any obstacles while carrying a boulder it loses power
            if (sdScript.boulderOneAttached && collisions.hasCollided == true && (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)))
            {
                losePower(3.5f);
            }

            //If the ship collides with any obstacles while carrying a boulder it loses power
            if (sdScript.boulderTwoAttached && collisions.hasCollided == true && (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)))
            {
                losePower(3.5f);
            }

            //If the ship collides with any obstacles while carrying a boulder it loses power
            if (sdScript.boulderThreeAttached && collisions.hasCollided == true && (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)))
            {
                losePower(3.5f);
            }

            elapsed = elapsed % 1f;
        }
        
        //Reloads the current scene if the ship runs out of power
        if (currentPower <= 0)
        {
            ReloadLevel();
        }
    }

    void losePower(float power)
    {
        currentPower -= power;
        powerBar.setPower(currentPower);
    }

    public void ReloadLevel()
    {
        //Reloads the current scene
       StartCoroutine(LevelLoader(SceneManager.GetActiveScene().buildIndex));
    }

    IEnumerator LevelLoader(int levelIndex)
    {
        anim.SetTrigger("StartFade");

        yield return new WaitForSeconds(gameTransitionTime);

        SceneManager.LoadScene(levelIndex);
    }

}
