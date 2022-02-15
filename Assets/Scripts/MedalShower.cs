using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MedalShower : MonoBehaviour
{
    [SerializeField] Sprite goldMedalSprite;
    [SerializeField] Sprite silverMedalSprite;
    [SerializeField] Image medalImage;

    public void SetGoldMedal() { medalImage.sprite = goldMedalSprite; }

    public void SetSilverMedal() { medalImage.sprite = silverMedalSprite; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
