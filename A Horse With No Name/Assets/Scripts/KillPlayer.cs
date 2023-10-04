using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{

    // Start is called before the first frame update
    void OnCollisionEnter2D(Collision2D otherObj)
    {
        if (otherObj.gameObject.tag == "Ground") {
            Debug.Log("Player hit the ground");
            GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>().playPlayerDiedSFX();
        }
    }
}
