using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    private GameObject[] gameOverComponents; // array of objects that have to appear when the game is overed
    private GameObject[] startGameComponents; // array of objects that have to appear when the game is about to start
    private GameObject[] gameComponents; // array of objects that have to appear when the game is started
    [SerializeField] GameObject text;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1; // resuming the game
        gameOverComponents = GameObject.FindGameObjectsWithTag("GameOverElement"); // find all those UI objects
        startGameComponents = GameObject.FindGameObjectsWithTag("GameStartElement"); // find all those UI objects
        gameComponents = GameObject.FindGameObjectsWithTag("GameElement"); // find all those UI objects
        DisableUIComponents(gameOverComponents); // disabling them on game start
        DisableUIComponents(gameComponents); // disabling them on game start
        EnableUIComponents(startGameComponents); // enabling them on game start
        DisableScore();
    }

    public void GameOver()
    {
        Time.timeScale = 0; // pausing the game
        EnableUIComponents(gameOverComponents); // activating all game over UI components
        DisableUIComponents(startGameComponents); // disabling all start components on game over
        DisableUIComponents(gameComponents); // disabling all game components on game over
        ScoreController scoreObject = FindObjectOfType<ScoreController>();
        DisableScore();
        scoreObject.RegisterBestScore();
        scoreObject.ShowStats();
    }

    public void EnableGameElements()
    {
        EnableUIComponents(gameComponents);
    }

    public void DisableScore()
    {
        text.SetActive(false);
    }

    public void EnableScore() 
    {
        text.SetActive(true);
    }

    public void DisableStartUI()
    {
        DisableUIComponents(startGameComponents);
    }

    private void DisableUIComponents(GameObject[] objectsToDisable)
    {
        foreach(GameObject obj in objectsToDisable)
        {
            obj.SetActive(false);
        }
    }

    public void EnableUIComponents(GameObject[] objectsToEnable)
    {
        foreach (GameObject obj in objectsToEnable)
        {
            obj.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
