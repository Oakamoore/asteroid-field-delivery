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

        bool isShipMoving = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow);

        const int defaultPowerLoss = 0.5f;
        const int collisionPowerLoss = 3.0f;
        const int maxPowerLoss = 3.5f;
        const int maxAttachmentPowerLoss = 1.5f;
        const int modifier = 0.3f;

        //Runs a check every second 
        if (elapsed >= 1f)
        {
            //If the ship is moving 
            if (isShipMoving)
            {
                losePower(defaultPowerLoss);
            }

            //If the ship collides with any obstacles it loses power
            else if(collisions.hasCollided == true)
            {
                losePower(collisionPowerLoss);
            }

            //If the ship is moving and is carrying the first boulder
            else if(sdScript.boulderOneAttached && isShipMoving)
            {
                losePower(maxAttachmentPowerLoss);
            }

            //If the ship is moving and is carrying the second boulder
            else if (sdScript.boulderTwoAttached && isShipMoving)
            {
                losePower(maxAttachmentPowerLoss - modifier);
            }

            //If the ship is moving and is carrying the third boulder
            else if (sdScript.boulderThreeAttached && isShipMoving)
            {
                losePower(maxAttachmentPowerLoss - (modifier * 2));
            }

            //If the ship collides with any obstacles while carrying a boulder it loses power
            else if ((sdScript.boulderOneAttached || sdScript.boulderTwoAttached || sdScript.boulderThreeAttached) &&
                 collisions.hasCollided == true && isShipMoving)
            {
                losePower(maxPowerLoss);
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
