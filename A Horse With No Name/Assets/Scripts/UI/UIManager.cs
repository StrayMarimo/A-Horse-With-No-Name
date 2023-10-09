// This script is used to manage the UI buttons in the game
using UnityEngine;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour
{
    private AudioManager audioManager;

    // called when the game starts
    void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    /// <summary>
    /// Called when the player goes back from leaderboard
    /// </summary>
    public void GoToGame()
    {
        // unload leaderboard scene
        SceneManager.UnloadSceneAsync("Leaderboard");

        // resume game
        audioManager.PlayClickSFX();
        audioManager.ResumeBGM();
        Time.timeScale = 1;
    }
    
    /// <summary>
    /// Called when the player goes to leaderboard
    /// </summary>
    public void GoToLeaderboards ()
    {
        // pause game
        audioManager.PlayClickSFX();
        audioManager.PauseBGM();
        Time.timeScale = 0;

        // load leaderboard scene
        SceneManager.LoadSceneAsync("Leaderboard", LoadSceneMode.Additive);
    }
}
