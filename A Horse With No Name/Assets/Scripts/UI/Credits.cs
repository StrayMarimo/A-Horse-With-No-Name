using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credits : MonoBehaviour
{
    public void onGoHome()
    {
        GameObject.FindGameObjectWithTag("Click").GetComponent<AudioSource>().Play();
        UnityEngine.SceneManagement.SceneManager.LoadScene("Main Menu");
    }
}
