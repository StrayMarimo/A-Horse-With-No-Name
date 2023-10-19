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

    void Awake()
    {
        if (PlayerPrefs.GetInt("isDay") == 0)
            toggleDayButton.SetActive(true);
        else
            toggleNightButton.SetActive(true);
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
        AudioListener.pause = true;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
        Time.timeScale = 1;
        AudioListener.pause = false;
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        AudioListener.pause = false;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
        AudioListener.pause = false;
    }

    public void ToggleMode()
    {
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
        
    }
}
