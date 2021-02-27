using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AddScore : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // FindObjectOfType<TextMeshPro>().GetComponent<ScoreText>().AddToScore();
        FindObjectOfType<ScoreText>().AddToScore();
/*        var tmp = GameObject.FindGameObjectWithTag("Score");
        tmp.GetComponent<ScoreText>().AddToScore();
        Debug.Log(tmp.ToString());*/
    }
}
