using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    
    [SerializeField]
    private UIManager UIManagerScript;

    [SerializeField]
    private GameObject toggleDayButton;

    [SerializeField]
    private GameObject toggleNightButton;

    [SerializeField]
    private BackgroundLoop backgroundLoop;

    private AudioManager audioManager;

    void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        if (PlayerPrefs.GetInt("isDay") == 0)
            toggleDayButton.SetActive(true);
        else
            toggleNightButton.SetActive(true);
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
        audioManager.PlayClickSFX();
        audioManager.PauseBGM();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
        Time.timeScale = 1;
        audioManager.PlayClickSFX();
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        audioManager.PlayClickSFX();
        audioManager.ResumeBGM();
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
        audioManager.PlayClickSFX();
    }

    public void ToggleMode()
    {
        audioManager.PlayClickSFX();
        if (PlayerPrefs.GetInt("isDay") == 0)
        {
            toggleNightButton.SetActive(false);
            toggleDayButton.SetActive(true); 
            PlayerPrefs.SetInt("isDay", 1);
            UIManagerScript.SetDayMode();
        }
        else
        {
            toggleDayButton.SetActive(false);
            toggleNightButton.SetActive(true); 
            PlayerPrefs.SetInt("isDay", 0);
            UIManagerScript.SetNightMode();
        }

        backgroundLoop.recalibrateBG();
    }
}
