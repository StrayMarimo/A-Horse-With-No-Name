// This script is used to display the score on the screen
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    // The text object for the score.
    [SerializeField]
    private TMP_Text scoreText;

    // The position of the player.
    [SerializeField]
    private Transform playerPos;
    public float score = 0;

    // Update is called once per frame
    void Update()
    {
        // If the player is dead, don't update the score.
        if (PlayerPrefs.GetInt("isDead") == 1) return;

        // Update the score rounded to 2 decimal places.
        score = Mathf.Round(playerPos.position.x * 100.0f) * 0.01f; 
        scoreText.text = string.Format("{0:0.##}", score);
    }
}
