using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource playerDiedSFX;
    private AudioSource playerWonSFX;
    private AudioSource bgm;
    private AudioSource playerNeighSFX;

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
        playerDiedSFX.Play();
    }

    public void playPlayerWonSFX() {
        bgm.Stop();
        playerWonSFX.Play();
    }

    public void playClickSFX() {
        clickSFX.Play();
    }
    
}
