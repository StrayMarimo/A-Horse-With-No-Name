// This script is used to kill the player when the head hits the ground.
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;

public class KillPlayer : MonoBehaviour
{
    // The script containing the player's score.
    [SerializeField]
    private Score scoreScript;

    // The game object for the game over screen.
    [SerializeField]
    private GameObject YouDied;

    // The list of high scores.
    private List<HighScoreEntry> scores = new();

    void Update()
    {
        // If the player presses R and player is dead, reset game.
        if (Input.GetKey(KeyCode.R) && PlayerPrefs.GetInt("isDead") == 1)
                SceneManager.LoadSceneAsync("Main");
    }

    /// <summary>
    /// Called when the head collides with something.
    /// </summary>
    /// <param name="otherObj"></param>
    async void OnCollisionEnter2D(Collision2D otherObj)
    {
        // If the player collides with the ground, kill the player.
        if (otherObj.gameObject.CompareTag("Ground") && 
            PlayerPrefs.GetInt("isDead") == 0) {
            // Play player died sound effect
            GameObject.FindGameObjectWithTag("Audio")
                .GetComponent<AudioManager>().PlayPlayerDiedSFX();
            // Set player to dead
            PlayerPrefs.SetInt("isDead", 1); 
            // Save score
            AddScore(PlayerPrefs.GetString("PlayerName"), scoreScript.score);
            
            // Show game over screen after 0.3 seconds
            await Task.Delay(300);
            YouDied.GetComponent<GameOver>().OnGameOver();
            YouDied.SetActive(true);
        }
    }

    /// <summary>
    /// Adds the given name and score to the high score list.
    /// </summary> 
    void AddScore(string entryName, float entryScore) {
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
