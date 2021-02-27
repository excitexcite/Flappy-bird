using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{

    public void ReloadLevel()
    {
        SceneManager.LoadScene(0); // reloading game scene
    }

    public void LoadMainMenu()
    {
        // TODO // loading main scene
    }

    public void Quit()
    {
        Application.Quit(); // quiting the application
    }

}
