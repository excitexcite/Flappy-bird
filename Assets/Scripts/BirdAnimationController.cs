using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Scipt to play (select) appropriate animation according to the setting
 */
public class BirdAnimationController : MonoBehaviour
{
    // reference to animator from bird object
    [SerializeField] Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        int  birdColor = PlayerPrefs.
            GetInt(SettingsController.BIRD_COLOR_KEY, SettingsController.YELLOW_BIRD_VALUE);
        SetAppropriateSprite(birdColor);
    }

    // Chose and set appropriate bird (animation)
    private void SetAppropriateSprite(int color)
    {
        if (color == SettingsController.YELLOW_BIRD_VALUE)
        {
            animator.Play("BirdFlyYellow");
        }
        else if (color == SettingsController.BLUE_BIRD_VALUE)
        {
            animator.Play("BirdFlyBlue");
        }
        else if (color == SettingsController.RED_BIRD_VALUE)
        {
            animator.Play("BirdFlyRed");
        }
    }
}
