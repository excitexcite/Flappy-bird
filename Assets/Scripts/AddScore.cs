using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


/**
 * Script to add points to score passing pipes. Places on empty object with collider in pipes prefab
 */
public class AddScore : MonoBehaviour
{
    [SerializeField] AudioClip pointGainSound;
    [SerializeField] [Range(0, 1)] float pointGainSoundVolume = 0.5f;

    // when pass the pipes
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ScoreController scoreObject = FindObjectOfType<ScoreController>();
        scoreObject.AddToScore();
        scoreObject.UpdateMainScoreText();
        // if sound settting is off, we don`t play music
        if (SettingsController.GetSoundValue() == SettingsController.SOUND_OFF_VALUE) { return; }
        AudioSource.PlayClipAtPoint(pointGainSound, Camera.main.transform.position, pointGainSoundVolume);
    }
}
