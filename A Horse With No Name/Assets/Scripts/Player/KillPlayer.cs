// This script is used to kill the player when the head hits the ground.
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillPlayer : MonoBehaviour
{
    // The script containing the player's score.
    [SerializeField]
    private Score scoreScript;

    // The game object for the game over screen.
    [SerializeField]
    private GameOver gameOverScript;

    void Update()
    {
        // If the player presses R and player is dead, reset game.
        if (Input.GetKey(KeyCode.Space) && PlayerPrefs.GetInt("isKeybindDisabled") == 0)
                SceneManager.LoadSceneAsync("Main");
    }

    /// <summary>
    /// Called when the head collides with something.
    /// </summary>
    /// <param name="otherObj"></param>
    void OnCollisionEnter2D(Collision2D otherObj)
    {
        // If the player collides with the ground, kill the player.
        if (otherObj.gameObject.CompareTag("Ground") && 
            PlayerPrefs.GetInt("isDead") == 0) {
            // Play player died sound effect
            GameObject.FindGameObjectWithTag("Audio")
                .GetComponent<AudioManager>().PlayPlayerDiedSFX();
            // enable game over screen
            gameOverScript.OnGameOver(false);
        }
    }
}
