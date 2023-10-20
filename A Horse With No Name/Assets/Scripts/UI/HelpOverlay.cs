using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpOverlay : MonoBehaviour
{
    [SerializeField] GameObject helpOverlay;
    private AudioManager audioManager;

    void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    public void Help()
    {
        helpOverlay.SetActive(true);
        Time.timeScale = 0;
        audioManager.PlayClickSFX();
        audioManager.PauseBGM();
    }

    public void Resume(bool fromGame)
    {
        helpOverlay.SetActive(false);
        if (fromGame)
        {
            Time.timeScale = 1;
            audioManager.PlayClickSFX();
            audioManager.ResumeBGM();
        }
    }
}
