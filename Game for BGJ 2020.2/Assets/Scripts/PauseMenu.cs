using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PauseMenu : MonoBehaviour
{

    public AudioMixer audioMixer;

    public PlayerMovement playerMov;

    public TimeRewind timeRew;

    public GameObject pauseMenuUI;

    public List<GameObject> backgrounds;

    public bool isPaused = false;

    public void setVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }

    public void SetEasyMode (bool isEasyMode)
    {
        playerMov.isEasyMode = isEasyMode; 
    }

    private void Start()
    {
        Time.timeScale = 1f;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume ()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    void Pause ()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
        ChangeBackgroundState();
    }

    public void ChangeBackgroundState()
    {
        //Loop through houses list
        for (int i = 0; i < backgrounds.Count; i++)
        {
            GameObject currentHouse = backgrounds[i];
            currentHouse.SetActive(false);
            if(timeRew.activeHouse == i)
            {
                currentHouse.SetActive(true);
            }
        }
    }
}
