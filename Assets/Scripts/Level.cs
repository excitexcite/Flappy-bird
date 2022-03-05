using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/**
 * Script to change scenes (screens)
 */

public class Level : MonoBehaviour
{
    public void ReloadLevel()
    {
        SceneManager.LoadScene(1); // reloading game scene
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
        ResumeGame();
    }

    public void LoadSettingsScene()
    {
        SceneManager.LoadScene(2);
        ResumeGame();
    }

    private void ResumeGame()
    {
        Time.timeScale = 1;
    }

    public void Quit()
    {
        Application.Quit(); // quiting the application
    }

}
