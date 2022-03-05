using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/**
 * Script to show score on gameplay, show current and best score on game over. Also this
 * scrip commands to show appropriate medal depending on gained score. The script saves score to
 * PlayerPrefs.
 */
public class ScoreController : MonoBehaviour
{
    public static string SCORE_KEY = "SCORE_KEY";
    [SerializeField] private int score = 0;
    [SerializeField] TextMeshProUGUI mainScoreTMP; // reference to big score number
    [SerializeField] TextMeshProUGUI statsScoreTMP; // reference to score in scorebar
    [SerializeField] TextMeshProUGUI bestScoreTMP; // reference to max score in scorebar
    [SerializeField] MedalShower shower; // reference to medalshower object
    int bestScore = 0; // variable represents new best result for current try

    void Start()
    {
        score = 0;
        //score = bestScore = 5;
        //PlayerPrefs.SetInt(SCORE_KEY, bestScore);
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
    
    // Calls from manager on game over. If we get better result we register it.
    public void RegisterBestScore()
    {
        // getting previous best result
        int prevBestScore = bestScore = GetBestScore();
        // if we didn`t play the game at all or we played and lost before the first point earned
        if (prevBestScore == 0 && score == 0 || prevBestScore != 0 && score == 0)
        {
            Debug.Log("If 1");
            //bestScore = score;
            //PlayerPrefs.SetInt(SCORE_KEY, bestScore);
            shower.showAppropriateMedal(0);
            return;
        }
        // if we didn`t play the game before but earned at least one point
        else if (prevBestScore == 0 && score != 0)
        {
            Debug.Log("If 2");
            bestScore = score;
            PlayerPrefs.SetInt(SCORE_KEY, bestScore);
            shower.showAppropriateMedal(3);
            return;
        }
        // if we played and got worse result or lower than 1.25 from the last best result
        if (score <= prevBestScore || score <= prevBestScore * 1.25)
        {
            Debug.Log("If 3");
            shower.showAppropriateMedal(0);
        }
        // if we played and get result better by 1/4 but worse by 1/2
        else if (score > prevBestScore * 1.25
            && score <= prevBestScore * 1.5)
        {
            Debug.Log("If 4");
            bestScore = score;
            PlayerPrefs.SetInt(SCORE_KEY, bestScore);
            shower.showAppropriateMedal(1);
        }
        // if we played and get result better by 1/2 but worse by 3/4
        else if (score > prevBestScore * 1.5
            && score <= prevBestScore * 1.75)
        {
            Debug.Log("If 5");
            bestScore = score;
            PlayerPrefs.SetInt(SCORE_KEY, bestScore);
            shower.showAppropriateMedal(2);
        }
        // if we played and get result better by 3/4
        else if (score > 1.75 * prevBestScore)
        {
            Debug.Log("If 6");
            bestScore = score;
            PlayerPrefs.SetInt(SCORE_KEY, bestScore);
            shower.showAppropriateMedal(3);
        }
    }

    // getting current best score value
    private int GetBestScore()
    {
        return PlayerPrefs.GetInt(SCORE_KEY, 0);
    }

    // function to show score and maxscore on scorebark, calls from manager on game over
    public void ShowStats()
    {
        if (statsScoreTMP)
        {
            statsScoreTMP.text = score.ToString();
        }
        // if bestScore equals zero, don`t show best score
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
