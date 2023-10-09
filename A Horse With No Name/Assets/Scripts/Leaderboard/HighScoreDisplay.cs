using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// This script displays the top 10 high scores in the leaderboard.
public class HighScoreDisplay : MonoBehaviour
{
    // The text objects for a row in the leaderboard.
    [SerializeField]
    private TMP_Text nameText;
    [SerializeField]
    private TMP_Text scoreText;

    /// <summary>
    /// Displays the given name and score in the leaderboard.
    /// </summary>
    /// <param name="name"></param>
    /// <param name="score"></param>
    public void DisplayHighScore(string name, float score)
    {
        nameText.text = name;
        scoreText.text = string.Format("{0:0.##}", score);
        if (name == "----") HideEntryDisplay();
    }

    /// <summary>
    /// Hides the entry display. 
    /// </summary>
    public void HideEntryDisplay()
    {
        nameText.text = "------";
        scoreText.text = "------";
    }
}