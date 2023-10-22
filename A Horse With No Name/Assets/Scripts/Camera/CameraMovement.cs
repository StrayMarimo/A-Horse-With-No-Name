// This script handles the movement of the camera.
// It follows the player character as it moves.
using UnityEngine;
using System.Collections.Generic;

public class CameraMovement : MonoBehaviour
{
    // The position of the player.
    private Transform playerPos;

    private Rigidbody2D playerRb;

    private GameObject[] bg1Pos; 
    private GameObject[] bg2Pos;
    private GameObject[] bg3Pos;
    private GameObject[] bg4Pos;

    // The position of the finish line.
    [SerializeField]
    private Transform finishLine;

    [SerializeField]
    private float[] bgSpeeds = {0.1f, 0.5f, 0.3f, 0.1f};
    void Start()
    {
         // Find the player character by tag and get its position.
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        playerRb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
    }
    
    // Update is called once per frame
    void Update()
    {
        bg1Pos = GameObject.FindGameObjectsWithTag("BG1");
        bg2Pos = GameObject.FindGameObjectsWithTag("BG2");
        bg3Pos = GameObject.FindGameObjectsWithTag("BG3");
        bg4Pos = GameObject.FindGameObjectsWithTag("BG4");
        print(playerRb.velocity.x);
        // If the player is between the start and finish lines,
        // move the camera to the player's position.
        if (playerPos.position.x < finishLine.position.x && PlayerPrefs.GetInt("isDead") == 0)
            {
                transform.position = new Vector3 (
                    playerPos.position.x, 
                    transform.position.y, 
                    transform.position.z);
                if (playerRb.velocity.x > 2.0f)
                {
                    for (int i = 0; i < bg1Pos.Length; i++)
                    {
                        bg1Pos[i].transform.position = new Vector3(bg1Pos[i].transform.position.x - bgSpeeds[0], bg1Pos[i].transform.position.y, bg1Pos[i].transform.position.z);
                        bg2Pos[i].transform.position = new Vector3(bg2Pos[i].transform.position.x - bgSpeeds[1], bg2Pos[i].transform.position.y, bg2Pos[i].transform.position.z);
                        bg3Pos[i].transform.position = new Vector3(bg3Pos[i].transform.position.x - bgSpeeds[2], bg3Pos[i].transform.position.y, bg3Pos[i].transform.position.z);
                        bg4Pos[i].transform.position = new Vector3(bg4Pos[i].transform.position.x - bgSpeeds[3], bg4Pos[i].transform.position.y, bg4Pos[i].transform.position.z);
                    }
                }
                else if (playerRb.velocity.x < -2.0f)
                {
                    for (int i = 0; i < bg1Pos.Length; i++)
                    {
                        bg1Pos[i].transform.position = new Vector3(bg1Pos[i].transform.position.x + bgSpeeds[0], bg1Pos[i].transform.position.y, bg1Pos[i].transform.position.z);
                        bg2Pos[i].transform.position = new Vector3(bg2Pos[i].transform.position.x + bgSpeeds[1], bg2Pos[i].transform.position.y, bg2Pos[i].transform.position.z);
                        bg3Pos[i].transform.position = new Vector3(bg3Pos[i].transform.position.x + bgSpeeds[2], bg3Pos[i].transform.position.y, bg3Pos[i].transform.position.z);
                        bg4Pos[i].transform.position = new Vector3(bg4Pos[i].transform.position.x + bgSpeeds[3], bg4Pos[i].transform.position.y, bg4Pos[i].transform.position.z);
                    }
                }
            }
        
    }

}