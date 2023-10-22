using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Threading.Tasks;

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

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) Resume();
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

    public async void ToggleMode()
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
        await Task.Delay(100);
        backgroundLoop.recalibrateBG();
    }
}
