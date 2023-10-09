using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScoreDisplay : MonoBehaviour
{
    public TMP_Text nameText;
    public TMP_Text scoreText;
    public void DisplayHighScore(string name, float score)
    {
        nameText.text = name;
        scoreText.text = string.Format("{0:0.##}", score);
    }
    public void HideEntryDisplay()
    {
        nameText.text = "------";
        scoreText.text = "------";
    }
}