﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    private GameObject[] gameOverComponents; // array of objects that have to appear when the game is overed
    private GameObject[] startGameComponents; // array of objects that have to appear when the game is about to start
    [SerializeField] GameObject text;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1; // resuming the game
        gameOverComponents = GameObject.FindGameObjectsWithTag("GameOverElement"); // find all those UI objects
        startGameComponents = GameObject.FindGameObjectsWithTag("GameStartElement"); // find all those UI objects
        DisableUIComponents(gameOverComponents); // disabling them on game start
        EnableUIComponents(startGameComponents); // enabling them on game start
        text.SetActive(false);
    }

    public void GameOver()
    {
        Time.timeScale = 0; // pausing the game
        EnableUIComponents(gameOverComponents); // activating all game over UI components
        DisableUIComponents(startGameComponents); // disabling all start components on game over
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
