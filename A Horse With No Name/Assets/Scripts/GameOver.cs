// This script is used to display the game over screen
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;
using System.Collections.Generic;

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

    // The list of high scores.
    private List<HighScoreEntry> scores = new();


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
        // Set player to dead
        PlayerPrefs.SetInt("isDead", 1); 
        
        // Save score
        AddScore(PlayerPrefs.GetString("PlayerName"), score);
            
        // Show game over screen
        gameObject.SetActive(true);

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

    /// <summary>
    /// Adds the given name and score to the high score list.
    /// </summary> 
    private void AddScore(string entryName, float entryScore) {
        // get current high scores from XML file
        scores = XMLManager.instance.LoadScores(); 

        // add new score
        scores.Add(new HighScoreEntry { name = entryName, score = entryScore });

        // trim list to top 10 scores
        scores.Sort((HighScoreEntry x, HighScoreEntry y) => y.score.CompareTo(x.score));
        scores = scores.GetRange(0, 10);

        // update new values
        PlayerPrefs.SetFloat("HighScore", scores[0].score);
        PlayerPrefs.SetString("TopTeam", scores[0].name);
        PlayerPrefs.SetFloat("LowScore", scores[9].score);

        // save new score to XML file
        XMLManager.instance.SaveScores(scores);
    }

}

