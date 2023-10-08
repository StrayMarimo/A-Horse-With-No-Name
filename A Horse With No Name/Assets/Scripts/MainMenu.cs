using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

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

    public void GoToMenu()
    {
        playClickSFX();
        SceneManager.LoadSceneAsync("Main Menu");
    }

    public void ChangeTeamName()
    {
        playClickSFX();
        SceneManager.LoadSceneAsync("Team Name");
    }

    public void playClickSFX() {
        GameObject click = GameObject.FindGameObjectWithTag("Click");
        DontDestroyOnLoad(click.transform.gameObject);
        click.GetComponent<AudioSource>().Play();
    }
}
