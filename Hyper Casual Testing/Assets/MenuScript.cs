using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public void Play()
    {
        int randomSceneIndex = Random.Range(1, SceneManager.sceneCountInBuildSettings);
        SceneManager.LoadScene(randomSceneIndex);
        Debug.Log("Scene No. " + randomSceneIndex + " Loaded");
    }

   public void Settings()
    {
        //Do Something Little Nigga Dont Keep Staring At Me Remove Me And Start Coding Bitch
        Debug.Log("This Will Open Settings!");
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("This Will Close The Game");
    }
}
