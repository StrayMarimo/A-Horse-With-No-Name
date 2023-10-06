using System.Collections.Generic;
using UnityEngine;
public class LeaderboardDisplay : MonoBehaviour
{
    public HighScoreDisplay[] highScoreDisplayArray;
    List<HighScoreEntry> scores = new List<HighScoreEntry>();
    void UpdateDisplay()
    {
        scores.Sort((HighScoreEntry x, HighScoreEntry y) => y.score.CompareTo(x.score));
        for (int i = 0; i < highScoreDisplayArray.Length; i++)
        {
            if (i < scores.Count)
            {
                highScoreDisplayArray[i].DisplayHighScore(scores[i].name, scores[i].score);
            }
            else
            {
                highScoreDisplayArray[i].HideEntryDisplay();
            }
        }

        print(scores[0].name + " " + scores[0].score);
    }
    void AddNewScore(string entryName, int entryScore)
    {
        scores.Add(new HighScoreEntry { name = entryName, score = entryScore });
        UpdateDisplay();
    }
}