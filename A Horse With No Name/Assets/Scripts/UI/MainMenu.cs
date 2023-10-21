// This script is used to control the main menu and its buttons
using System;
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

    public float idleTime = 0f;
    public Boolean isIdle = false;

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

    private void Update() {
        // Check if any input is detected
        if (Input.anyKey || Input.GetAxis("Mouse X") != 0f || Input.GetAxis("Mouse Y") != 0f)
        {
            // Reset idle time and set isIdle to false
            ResetIdleState();
            //Debug.Log("Reset Idle");
        }
        else
        {
            // Increment idle time
            idleTime += Time.deltaTime;

            // Check if idle time exceeds 15 seconds and player is not already idle
            if (idleTime >= 10f && !isIdle)
            {
                // Set isIdle to true to prevent multiple prints
                isIdle = true;
            }
        }

        if(isIdle){
            SceneManager.LoadScene("CutScene");
            bgm.GetComponent<AudioSource>().Stop();
        }
    }

    private void ResetIdleState()
    {
        idleTime = 0f;
        isIdle = false;
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
