using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LandingCheck : MonoBehaviour
{

    int collisionCount = 0;
    public float transitionTime;
    public Animator anim;

    private void Update()
    {
        //When all three boulders have reached the landing point
        if(collisionCount == 3)
        {
            NextLevel();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Boulder1")
        {
            collisionCount++;
        }

        if (other.gameObject.name == "Boulder2")
        {
            collisionCount++;
        }

        if (other.gameObject.name == "Boulder3")
        {
            collisionCount++;
        }
    }

    public void NextLevel()
    {
        //loads the next scene
        StartCoroutine(LevelLoader(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LevelLoader(int levelIndex)
    {
        anim.SetTrigger("StartFade");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }

}
