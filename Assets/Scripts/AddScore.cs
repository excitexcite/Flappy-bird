using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AddScore : MonoBehaviour
{
    [SerializeField] AudioClip pointGainSound;
    [SerializeField] [Range(0, 1)] float pointGainSoundVolume = 0.5f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        FindObjectOfType<ScoreText>().AddToScore();
        AudioSource.PlayClipAtPoint(pointGainSound, Camera.main.transform.position, pointGainSoundVolume);
    }
}
