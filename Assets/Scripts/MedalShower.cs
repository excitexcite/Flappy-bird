using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
 * Script to enable appropriate medal sprite depending on gained score
 */
public class MedalShower : MonoBehaviour
{
    [SerializeField] Sprite[] medals; // reference to medal object
    [SerializeField] Image medalImage; // array of medal images

    // 
    public void showAppropriateMedal(int index) 
    {
        medalImage.sprite = medals[index];
    }
}
