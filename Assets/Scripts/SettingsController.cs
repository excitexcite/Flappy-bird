using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/**
 * Script that allow change settings (bird skin, background, sound setting). 
 * Places on SettingsController object on each scene.
 */
public class SettingsController : MonoBehaviour
{

    // keys and values to work with PlayerPrefs
    public static string BIRD_COLOR_KEY = "Color";
    public static int YELLOW_BIRD_VALUE = 0;
    public static int RED_BIRD_VALUE = 1;
    public static int BLUE_BIRD_VALUE = 2;
    public static string SOUND_KEY = "Sound";
    public static int SOUND_ON_VALUE = 1;
    public static int SOUND_OFF_VALUE = 0;
    public static string BACKGROUND_KEY = "Background";
    public static string BACKGROUND_DAY_VALUE = "Day";
    public static string BACKGROUND_NIGHT_VALUE = "Night";

    // active bird is look bigger than unselected
    [Header("Bird skin setting")]
    [SerializeField] GameObject[] birdSkins;
    private Vector3 defaultSize = new Vector3(7, 7, 7);
    private Vector3 selectedSize = new Vector3(10, 10, 10);

    [Header("Day-Night setting")]
    [SerializeField] GameObject background;
    [SerializeField] Sprite daySprite;
    [SerializeField] Sprite nightSprite;
    [SerializeField] TextMeshProUGUI dayNightText;
    private string dayString = "DAY";
    private string nightString = "NIGHT";

    [Header("Sound setting")]
    [SerializeField] TextMeshProUGUI soundText;
    private string soundOnString = "ON";
    private string soundOffString = "OFF";
    private int soundOn = 1;
    private int soundOff = 0;

    private Color white = Color.white;
    private Color black = Color.black;

    private void Start()
    {
        SetInitialValues();
    }

    // setting initial settings values on screen accroding to already setted value (or default values)
    private void SetInitialValues()
    {
        int skinNum = PlayerPrefs.GetInt(BIRD_COLOR_KEY, YELLOW_BIRD_VALUE);
        SetUpSkins(skinNum);
     

        if (PlayerPrefs.GetString(BACKGROUND_KEY, BACKGROUND_DAY_VALUE)
            .Equals(BACKGROUND_DAY_VALUE))
        {
            background.GetComponent<SpriteRenderer>().sprite = daySprite;
            ChangeTextApperiance(dayNightText, black, nightString);
        }
        else
        {
            background.GetComponent<SpriteRenderer>().sprite = nightSprite;
            ChangeTextApperiance(dayNightText, white, dayString);
        }

        if (PlayerPrefs.GetInt(SOUND_KEY, SOUND_ON_VALUE) == soundOn)
        {
            ChangeTextApperiance(soundText, black, soundOnString);
        }
        else
        {
            ChangeTextApperiance(soundText, white, soundOffString);
        }
    }

    // Making selected bird skin bigger than others
    private void SetUpSkins(int skinNum)
    {
        for (int i = 0; i < birdSkins.Length; i++)
        {
            if (i == skinNum)
            {
                //Debug.Log("Enable" + i);
                birdSkins[i].GetComponent<RectTransform>().localScale = selectedSize;
                PlayerPrefs.SetInt(BIRD_COLOR_KEY, i);
            }
            else
            {
                //Debug.Log("Disable" + i);
                birdSkins[i].GetComponent<RectTransform>().localScale = defaultSize;
            }
        }
    }

    public void ChangeSkin(int index)
    {
        //PlayerPrefs.SetInt(BIRD_COLOR_KEY, index);
        SetUpSkins(index);
    }

    // function to change text and it`s color for any text object
    private void ChangeTextApperiance(TextMeshProUGUI tmpro, Color color, string text)
    {
        if (tmpro == null) { return; }
        tmpro.text = text;
        tmpro.color = color;
    }

    // changing theme according to selected setting, placed on button
    public void changeTheme()
    {
        if (PlayerPrefs.GetString(BACKGROUND_KEY, BACKGROUND_DAY_VALUE)
            .Equals(BACKGROUND_DAY_VALUE)) {
            background.GetComponent<SpriteRenderer>().sprite = nightSprite;
            ChangeTextApperiance(dayNightText, white, dayString);
            PlayerPrefs.SetString(BACKGROUND_KEY, BACKGROUND_NIGHT_VALUE);
        } 
        else
        {
            background.GetComponent<SpriteRenderer>().sprite = daySprite;
            ChangeTextApperiance(dayNightText, black, nightString);
            PlayerPrefs.SetString(BACKGROUND_KEY, BACKGROUND_DAY_VALUE);
        }
    }

    public static string GetThemeValue()
    {
        return PlayerPrefs.GetString(BACKGROUND_KEY, BACKGROUND_DAY_VALUE);
    }

    // changing sound according to selected setting, placed on button
    public void changeSoundSetting()
    {
        if (PlayerPrefs.GetInt(SOUND_KEY, SOUND_ON_VALUE) == soundOn) {
            ChangeTextApperiance(soundText, white, soundOffString);
            PlayerPrefs.SetInt(SOUND_KEY, soundOff);
            Debug.Log("Sound off");
        }
        else
        {
            ChangeTextApperiance(soundText, black, soundOnString);
            PlayerPrefs.SetInt(SOUND_KEY, soundOn);
            Debug.Log("Sound On");
        }
    }

    public static int GetSoundValue()
    {
        return PlayerPrefs.GetInt(SOUND_KEY, SOUND_ON_VALUE);
    }

    public static void SetYellowBirdValue()
    {
        PlayerPrefs.SetInt(BIRD_COLOR_KEY, YELLOW_BIRD_VALUE);
    }

    public static void SetBlueBirdValue()
    {
        PlayerPrefs.SetInt(BIRD_COLOR_KEY, BLUE_BIRD_VALUE);
    }

    public static void SetRedBirdValue()
    {
        PlayerPrefs.SetInt(BIRD_COLOR_KEY, RED_BIRD_VALUE);
    }

    public static int GetBirdValue()
    {
        return PlayerPrefs.GetInt(BIRD_COLOR_KEY, YELLOW_BIRD_VALUE);
    }
}
