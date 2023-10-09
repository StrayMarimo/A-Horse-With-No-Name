// This script is used to detect when the player has won the game.
using UnityEngine;

public class PlayerWon : MonoBehaviour
{

    [SerializeField]
    private GameOver gameOverScript;
    /// <summary>
    /// Called when the player reaches finish line.
    /// </summary>
    void OnTriggerEnter2D(Collider2D otherObj)
    {
        // If the player collides with the finish line, end the game.
        if (otherObj.gameObject.CompareTag("Player")) {
            // Play player won sound effect
            GameObject.FindGameObjectWithTag("Audio")
                .GetComponent<AudioManager>().PlayPlayerWonSFX();
            // enable game over screen
            gameOverScript.OnGameOver();
        }
    }
}
