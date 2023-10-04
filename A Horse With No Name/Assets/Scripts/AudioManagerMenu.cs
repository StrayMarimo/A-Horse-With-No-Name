using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerMenu : MonoBehaviour
{
    private AudioSource clickSFX;
    
    void Start()
    {
        clickSFX = GameObject.FindGameObjectWithTag("Click").GetComponent<AudioSource>(); 
    }

    public void playClickSFX() {
        clickSFX.Play();
    }
}
