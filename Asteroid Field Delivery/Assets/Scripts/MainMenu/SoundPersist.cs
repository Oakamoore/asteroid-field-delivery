using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundPersist : MonoBehaviour
{

    private void Awake()
    {
        //Persists the game object upon the loading on a new scene
        DontDestroyOnLoad(this.transform.gameObject);
    }

    private void Update()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        //Stops playing the music when the play beats the game
        if(currentScene.name == "EndCard")
        {
            Destroy(this.gameObject);
        }
    }

}
