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
    }

    public void Resume()
    {
        helpOverlay.SetActive(false);
        Time.timeScale = 1;
    }
}
