using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraMovement : MonoBehaviour
{

    private GameObject Player;
    private GameObject finishLine;
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        finishLine = GameObject.FindGameObjectWithTag("FinishLine");
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.transform.position.x > 0 && Player.transform.position.x < finishLine.transform.position.x)
        {
            this.transform.position = new Vector3 (Player.transform.position.x, 0, -10);
        }
    }

}