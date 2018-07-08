using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    public void LoadScene(string name)
    {
        Bricks.breakableCount = 0;
        SceneManager.LoadScene(name);
    }

    public void LoadNextScene()
    {
        Bricks.breakableCount = 0;
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadStartScene()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        print("Quit requested");
        Application.Quit();
    }

    public void BrickDestroyed()
    {
        if(Bricks.breakableCount <= 0)
        {
            LoadNextScene();
        }
    }
}