// This script is used to control the main menu and its buttons
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject DayBG;
    
    [SerializeField]
    private GameObject NightBG;

    [SerializeField]
    private GameObject helpOverlay;

    [SerializeField]
    private GameObject bgm;

    void Start()
    {
        if (!bgm.GetComponent<AudioSource>().isPlaying)
            bgm.GetComponent<AudioSource>().Play();
        if (!PlayerPrefs.HasKey("isDay"))
            PlayerPrefs.SetInt("isDay", 1);
        
        if (PlayerPrefs.GetInt("isDay") == 1)
        {
            NightBG.SetActive(false);
            DayBG.SetActive(true);
        }
        else
        {
            DayBG.SetActive(false);
            NightBG.SetActive(true);
        }
        DontDestroyOnLoad(GameObject.FindGameObjectWithTag("ThemeMusic"));
    }

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

    // Called when the player clicks the play button from home page
    public void HideHelp()
    {
        PlayClickSFX();
        helpOverlay.SetActive(false);
    }

    // plays the click sound effect when a button is clicked
    private void PlayClickSFX() {
        GameObject click = GameObject.FindGameObjectWithTag("Click");
        DontDestroyOnLoad(click.transform.gameObject);
        click.GetComponent<AudioSource>().Play();
    }
}
