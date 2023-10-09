using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource playerDiedSFX;
    private AudioSource playerWonSFX;
    private AudioSource bgm;
    private AudioSource playerNeighSFX;
    private bool isNeighingPaused = false;

    private AudioSource clickSFX;
    // Start is called before the first frame update
    void Start()
    {
        bgm = GameObject.FindGameObjectWithTag("BGM").GetComponent<AudioSource>();
        playerDiedSFX = GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>();
        playerWonSFX = GameObject.FindGameObjectWithTag("FinishLine").GetComponent<AudioSource>();
        playerNeighSFX = GameObject.FindGameObjectWithTag("Horse").GetComponent<AudioSource>();
        clickSFX = GameObject.FindGameObjectWithTag("Click").GetComponent<AudioSource>();
        bgm.Play();
        playerNeighSFX.Play();
    }

    public void playPlayerDiedSFX() {
        bgm.Stop();
        if (playerNeighSFX.isPlaying) {
            playerNeighSFX.Stop();
        }
        playerDiedSFX.Play();
    }

    public void pauseBGM() {
        bgm.Pause();
        if (playerNeighSFX.isPlaying) {
            playerNeighSFX.Pause();
            isNeighingPaused = true;
        }
    }

    public void resumeBGM() {
        bgm.Play();
        if (isNeighingPaused) {
            playerNeighSFX.Play();
            isNeighingPaused = false;
        }
    }

    public void playPlayerWonSFX() {
        bgm.Stop();
        if (playerNeighSFX.isPlaying) {
            playerNeighSFX.Stop();
        }
        playerWonSFX.Play();
    }

    public void playClickSFX() {
        clickSFX.Play();
    }
    
}
