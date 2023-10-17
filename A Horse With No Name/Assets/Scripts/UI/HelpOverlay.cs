using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpOverlay : MonoBehaviour
{
    [SerializeField] GameObject helpOverlay;

    public void Help()
    {
        helpOverlay.SetActive(true);
        Time.timeScale = 0;
        AudioListener.pause = true;
    }

    public void Resume()
    {
        helpOverlay.SetActive(false);
        Time.timeScale = 1;
        AudioListener.pause = false;
    }
}
