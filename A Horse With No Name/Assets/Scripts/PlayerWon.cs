using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWon : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D otherObj)
    {
        if (otherObj.gameObject.tag == "Player") {
            print("Player won!");
            GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>().playPlayerWonSFX();
        }
    }
}
