// This script is used to load and save the high scores
// to be displayed in the leaderboard.
// It also updates the XML file containing the high scores
using System.Collections.Generic;
using UnityEngine;
public class LeaderboardDisplay : MonoBehaviour
{
    // rows in leaderboard table
    [SerializeField]
    private HighScoreDisplay[] highScoreDisplayArray;

    // list of high scores.
    private List<HighScoreEntry> scores = new();

    void Start()
    {
        // get current high scores from XML file
        scores = XMLManager.instance.LoadScores();

        // if no high scores, add 10 empty entries
        if (scores.Count == 0)
            for (int i = 0; i < 10; i++)
                scores.Add(new HighScoreEntry { name = "------", score = 0 });

        // update leaderboard and game data
        UpdateDisplay();
        PlayerPrefs.SetFloat("HighScore", scores[0].score);
        PlayerPrefs.SetString("TopTeam", scores[0].name);
        PlayerPrefs.SetFloat("LowScore", scores[9].score);
    }

    /// <summary>
    /// Updates the leaderboard display.
    /// </summary>
    void UpdateDisplay()
    {
        // get top 10 scores and save to XML file
        scores.Sort((HighScoreEntry x, HighScoreEntry y) => y.score.CompareTo(x.score));
        scores = scores.GetRange(0, 10);
        XMLManager.instance.SaveScores(scores);

        // display top 10 scores in leaderboard
        for (int i = 0; i < highScoreDisplayArray.Length; i++)
        {
            if (i < scores.Count)
                highScoreDisplayArray[i].DisplayHighScore(scores[i].name, scores[i].score);
            else
                highScoreDisplayArray[i].HideEntryDisplay();
        }
    }

    /// <summary>
    /// Adds the given name and score to the high score list.
    /// </summary>
    /// <param name="entryName"></param>
    /// <param name="entryScore"></param>
    public void AddNewScore(string entryName, float entryScore)
    {
        scores.Add(new HighScoreEntry { name = entryName, score = entryScore });
    }
}