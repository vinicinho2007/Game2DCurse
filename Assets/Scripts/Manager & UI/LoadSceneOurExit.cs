using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneOurExit : MonoBehaviour
{
    public void LoadScene(string scene)
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(scene);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}