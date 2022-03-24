using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnyKeyToStart : MonoBehaviour
{

    public Animator anim;

    public float transitionTime = 3f;

    void Update()
    {
        if (Input.anyKeyDown)
        {
            anim.Play("CrossfadeEnd");
            StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
        }
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        anim.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }

}
