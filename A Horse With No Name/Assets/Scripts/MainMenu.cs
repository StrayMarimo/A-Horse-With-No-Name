// This script is used to control the main menu and its buttons
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    // Called when the player clicks the play button.
    public void PlayGame()
    { 
        PlayClickSFX();
        SceneManager.LoadSceneAsync("Main");
    }

    // Called when the player clicks the quit button.
    public void QuitGame()
    {
        PlayClickSFX();
        Application.Quit();
    }

    // Called when the player Go To Menu button.
    public void GoToMenu()
    {
        PlayClickSFX();
        SceneManager.LoadSceneAsync("Main Menu");
    }

    // Called when the player clicks the play button from home page
    public void ChangeTeamName()
    {
        PlayClickSFX();
        SceneManager.LoadSceneAsync("Team Name");
    }

    // plays the click sound effect when a button is clicked
    private void PlayClickSFX() {
        GameObject click = GameObject.FindGameObjectWithTag("Click");
        DontDestroyOnLoad(click.transform.gameObject);
        click.GetComponent<AudioSource>().Play();
    }
}
