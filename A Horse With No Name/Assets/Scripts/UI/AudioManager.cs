// This script handles the audio for the game.
// It listens for events and plays the appropriate sound effects.
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // The audio sources for the sound effects.
    [SerializeField]
    private AudioSource playerDiedSFX;

    [SerializeField]
    private AudioSource playerWonSFX;

    [SerializeField]
    private AudioSource bgm;

    [SerializeField]
    private AudioSource playerNeighSFX;

    // not serialized because it uses the tag to find the object
    private AudioSource clickSFX;

    // Whether the neighing sound effect is paused.
    private bool isNeighingPaused = false;

    /// <summary>
    /// when the game starts, play the background music 
    /// and neighing sound effect.
    /// </summary>
    void Start()
    {
        bgm.Play();
        playerNeighSFX.Play();

        // find the click sound effect
        clickSFX = GameObject.FindGameObjectWithTag("Click")
            .GetComponent<AudioSource>();
        GameObject.FindGameObjectWithTag("ThemeMusic").GetComponent<AudioSource>().Stop();
    }

    /// <summary>
    /// Stops the background music and plays the player died sound effect.
    public void PlayPlayerDiedSFX() 
    {
        bgm.Stop();
        if (playerNeighSFX.isPlaying) playerNeighSFX.Stop();
        playerDiedSFX.Play();
    }

    /// <summary>
    /// Puses the background music and neighing sound effect.
    /// </summary>
    public void PauseBGM() 
    {
        bgm.Pause();
        if (playerNeighSFX.isPlaying) 
        {
            playerNeighSFX.Pause();
            isNeighingPaused = true;
        }
    }

    /// <summary>
    /// Resumes the background music and neighing sound effect.
    /// </summary>
    public void ResumeBGM() 
    {
        if (PlayerPrefs.GetInt("isDead") == 0) bgm.Play();
        if (isNeighingPaused) {
            playerNeighSFX.Play();
            isNeighingPaused = false;
        }
    }

    /// <summary>
    /// Stops the background music and plays the player won sound effect.
    /// </summary>
    public void PlayPlayerWonSFX() 
    {
        bgm.Stop();
        if (playerNeighSFX.isPlaying) playerNeighSFX.Stop();
        playerWonSFX.Play();
    }

    /// <summary>
    /// Plays the click sound effect.
    /// </summary>
    public void PlayClickSFX() 
    {
        clickSFX.Play();
    }
    
}
