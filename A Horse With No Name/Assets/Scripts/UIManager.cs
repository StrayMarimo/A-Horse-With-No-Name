using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;
using UnityEngine.EventSystems;
public class UIManager : MonoBehaviour
{
    private AudioManager audioManager;
    void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    public void GoToGame()
    {
        SceneManager.UnloadSceneAsync("Leaderboard");
        audioManager.PlayClickSFX();
        audioManager.ResumeBGM();
        Time.timeScale = 1;
    }
    
    public void GoToLeaderboards ()
    {
        audioManager.PlayClickSFX();
        audioManager.PauseBGM();
        Time.timeScale = 0;
        GameObject.FindGameObjectWithTag("Click").GetComponent<AudioSource>().Play();
        SceneManager.LoadSceneAsync("Leaderboard", LoadSceneMode.Additive);
    }
}
