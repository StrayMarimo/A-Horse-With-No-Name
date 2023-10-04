using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    
    public void PlayGame()
    {
        playClickSFX();
        SceneManager.LoadSceneAsync("Main");
    }

    public void QuitGame()
    {
        playClickSFX();
        Application.Quit();
    }

    private void playClickSFX() {
        GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManagerMenu>().playClickSFX();
    }
}
