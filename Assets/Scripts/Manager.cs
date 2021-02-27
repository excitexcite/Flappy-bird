using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{

    [SerializeField] Canvas gameCanvas; // reference to the main canvas
    private GameObject[] gameOverComponents; // array of objects that have to appear when the game is overed

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1; // resuming the game
        gameOverComponents = GameObject.FindGameObjectsWithTag("GameOverElement"); // find all those UI objects
        DisableGameOverComponents(); // disabling them on game start
    }

    public void GameOver()
    {
        Time.timeScale = 0; // pausing the game
        EnableGameOverComponents(); // activating all game over UI components
    }

    private void DisableGameOverComponents()
    {
        foreach(GameObject obj in gameOverComponents)
        {
            obj.SetActive(false);
        }
    }

    private void EnableGameOverComponents()
    {
        foreach (GameObject obj in gameOverComponents)
        {
            obj.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
