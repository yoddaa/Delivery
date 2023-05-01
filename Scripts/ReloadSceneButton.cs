using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadSceneButton : MonoBehaviour
{
    public void ReloadScene()
    {
        // Get the name of the current scene
        string currentSceneName = SceneManager.GetActiveScene().name;

        // Reload the current scene
        SceneManager.LoadScene(currentSceneName);
    }

    public void LoadSceneByIndex(int sceneIndex)
    {
        // Load the scene with the specified build index
        SceneManager.LoadScene(sceneIndex);
    }

    public void QuitTheGame()
    {
        //Application.Quit();
        
    }

    private void OnApplicationQuit()
    {
       
    }
}