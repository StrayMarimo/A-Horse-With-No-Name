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
    private GameObject wonTitle;

    [SerializeField]
    private GameObject lostTitle;

    [SerializeField]
    private TMP_Text nameText;

    [SerializeField]
    private GameObject leaderboardBtn;

    [SerializeField]
    private GameObject homeBtn;

    [SerializeField]
    private GameObject pauseBtn;

    [SerializeField]
    private GameObject scoreCanvas;

    // The script containing the player's score.
    [SerializeField]
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
        pauseBtn.SetActive(false);
        leaderboardBtn.SetActive(true);
        homeBtn.SetActive(true);
        scoreCanvas.SetActive(false);
         // get current score
        float score = scoreScript.score;
        // Set player to dead
        PlayerPrefs.SetInt("isDead", 1); 
        
        // Save score
        AddScore(PlayerPrefs.GetString("PlayerName"), score);
            
        // Show game over screen
        gameObject.SetActive(true);

        // // update high score
        // highScoreText.text = $"Best: {PlayerPrefs.GetFloat("HighScore"):0.##} meters ({PlayerPrefs.GetString("TopTeam")})";

        // update name and score of player
        nameText.text = PlayerPrefs.GetString("PlayerName");
        scoreText.text = $"{score:0.##} meters";

        // update rank message
        if (score > PlayerPrefs.GetFloat("HighScore"))
        {
            lostTitle.SetActive(false);
            wonTitle.SetActive(true);
        }
        else if (score > PlayerPrefs.GetFloat("LowScore"))
        {
            lostTitle.SetActive(false);
            wonTitle.SetActive(true);
        }
        else
        {
            wonTitle.SetActive(false);
            lostTitle.SetActive(true);
        }
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

