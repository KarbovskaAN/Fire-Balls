using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Serialization;

public class Menu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    
    public GameObject PauseMenu;
    public GameObject ButtonSound;
    
    public Sprite OffSoundSprite;
    public Sprite ButtonOnSound;

    public AudioSource _audioSource;

    public void InitializeMenu()
    {
        AudioSource audio = GameObject.FindWithTag("Audio").GetComponent<AudioSource>();

        if (audio != null)
        {
            _audioSource = audio;
        }

        if (PlayerPrefs.GetFloat("CurrentVolume") == 0)
        {
          
            ButtonSound.GetComponent<Image>().sprite = ButtonOnSound;
        }
        else
        {
            ButtonSound.GetComponent<Image>().sprite = OffSoundSprite;
        }
    }

    public void Pause()
    {
        PauseMenu.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Continue()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void SwitchSound()
    {
        if (ButtonSound.GetComponent<Image>().sprite == ButtonOnSound)
        {
            ButtonSound.GetComponent<Image>().sprite = OffSoundSprite;
            _audioSource.volume = 0f;
            PlayerPrefs.SetFloat("CurrentVolume", 1);
        }
        else
        {
            ButtonSound.GetComponent<Image>().sprite = ButtonOnSound;
            _audioSource.volume = 1f;
            PlayerPrefs.SetFloat("CurrentVolume", 0);
        }
    }

    public void UpdateSound()
    {
        if (PlayerPrefs.GetFloat("CurrentVolume") == 0)
        {
            _audioSource.volume = 1f ;
        }
        else
        {
            _audioSource.volume = 0f ;
        }
        
    }
}
