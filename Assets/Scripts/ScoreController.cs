using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreController : MonoBehaviour
{
    public static string SCORE_KEY = "SCORE_KEY";
    [SerializeField] private int score = 0;
    [SerializeField] TextMeshProUGUI mainScoreTMP; // reference to big score number
    [SerializeField] TextMeshProUGUI statsScoreTMP; // reference to score in scorebar
    [SerializeField] TextMeshProUGUI bestScoreTMP; // reference to max score in scorebar
    [SerializeField] MedalShower shower; // reference to medalshower object
    int bestScore = 0;

    void Start()
    {
        score = 0;
    }

    void Update()
    {
/*        var text = FindObjectOfType<TextMeshProUGUI>();
        if (text) 
        { 
            text.text = score.ToString();
        }*/

        //GetComponent<Text>().text = score.ToString();
    }
    
    // registering new max score value if that is
    public void RegisterBestScore()
    {
        int prevBestScore = GetBestScore();
        if (prevBestScore < score)
        {
            bestScore = score;
            PlayerPrefs.SetInt(SCORE_KEY, bestScore);
            shower.SetGoldMedal();
            //PlayerPrefs.Save();
        }
        else
        {
            bestScore = prevBestScore;
            shower.SetSilverMedal();
        }
    }

    // getting current best score value
    private int GetBestScore()
    {
        return PlayerPrefs.GetInt(SCORE_KEY, 0);
    }

    // function to show score and maxscore on scorebar
    public void ShowStats()
    {
        if (statsScoreTMP)
        {
            statsScoreTMP.text = score.ToString();
        }
        if (bestScore == 0)
        {
            bestScoreTMP.text = "";
        }
        else
        {
            bestScoreTMP.text = bestScore.ToString();
        }
    }
    
    // public function to increase score that is called on collision with space between pipes
    public void AddToScore() { score++; }

    // public function to update scoreUI that is called on collision with space between pipes
    public void UpdateMainScoreText()
    {
        mainScoreTMP.text = score.ToString();
    }
}
