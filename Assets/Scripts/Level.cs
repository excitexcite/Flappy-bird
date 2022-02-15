using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    private void ResumeGame()
    {
        Time.timeScale = 1;
    }

    public void Quit()
    {
        Application.Quit(); // quiting the application
    }

}
