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


    public void SavePlayer()
    {
        playClickSFX();
        GameObject input = GameObject.FindGameObjectWithTag("NameInput");
        PlayerPrefs.SetString("PlayerName", input.GetComponent<TMP_InputField>().text);
        PlayerPrefs.Save();
        print(PlayerPrefs.GetString("PlayerName"));
        SceneManager.LoadSceneAsync("Main");
    }

    private void playClickSFX() {
        GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManagerMenu>().playClickSFX();
    }
}
