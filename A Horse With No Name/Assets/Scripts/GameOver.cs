// This script is used to display the game over screen
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    // The text objects for the game over screen.
    [SerializeField]
    private TMP_Text scoreText;

    [SerializeField]
    private TMP_Text highScoreText;

    [SerializeField]
    private TMP_Text nameText;

    [SerializeField]
    private TMP_Text rankText;

    [SerializeField]

    // The script containing the player's score.
    private Score scoreScript;

    private AudioManager audioManager;

    // called when the game starts
    void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    /// <summary>
    /// Called when the player clicks the play again button.
    /// </summary>
    public void OnPlayAgain()
    {
        audioManager.PlayClickSFX();
        gameObject.SetActive(false);
        SceneManager.LoadSceneAsync("Main");
    }

    /// <summary>
    /// Called when the player clicks the quit button.
    /// </summary>
    public void OnQuit()
    {
        audioManager.PlayClickSFX();
        SceneManager.LoadSceneAsync("Main Menu");
    }

    /// <summary>
    /// Called when the player dies.
    /// </summary> 
    public void OnGameOver()
    {
        // get current score
        float score = scoreScript.score;

        // update high score
        highScoreText.text = $"Best: {PlayerPrefs.GetFloat("HighScore"):0.##} meters ({PlayerPrefs.GetString("TopTeam")})";

        // update name and score of player
        nameText.text = PlayerPrefs.GetString("PlayerName");
        scoreText.text = $"You ran an incredible {score:0.##} meters without falling";

        // update rank message
        if (score > PlayerPrefs.GetFloat("HighScore"))
            rankText.text = "New High Score!";
        else if (score > PlayerPrefs.GetFloat("LowScore"))
            rankText.text = "Congratulations! You made it in our top 10. Check out the leaderboard to see where you rank!";
        else 
            rankText.text = "You didn't make it into our top 10. Try again to see if you can make it!";
    }

}

