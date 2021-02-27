﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreText : MonoBehaviour
{

    [SerializeField] private int score = 0;

    void Start()
    {
        score = 0;
    }

    void Update()
    {
        FindObjectOfType<TextMeshProUGUI>().text = score.ToString();
        //GetComponent<Text>().text = score.ToString();
    }
    
    public void AddToScore() { score++; }

}
