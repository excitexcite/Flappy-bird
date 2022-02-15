using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseController : MonoBehaviour
{
    [SerializeField] Button pauseButton;
    [SerializeField] Image buttonImage;
    [SerializeField] Sprite pauseSprite;
    [SerializeField] Sprite resumeSprite;

    bool isPaused = false;

    // Start is called before the first frame update
    void Start()
    {
        pauseButton.onClick.AddListener(PauseGame);
        //GetComponent<Button>().onClick.AddListener(PauseGame);
    }

    public void PauseGame()
    {
        if (!isPaused)
        {
            Time.timeScale = 0;
            isPaused = true;
            AudioListener.pause = true;
            buttonImage.sprite = resumeSprite;
        }
        else
        {
            isPaused = false;
            Time.timeScale = 1;
            AudioListener.pause = false;
            buttonImage.sprite = pauseSprite;
        }
    }

    public bool IsPaused() { return isPaused; }
}
