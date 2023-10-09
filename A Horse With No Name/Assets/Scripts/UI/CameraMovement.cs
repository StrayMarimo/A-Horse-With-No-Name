// This script handles the movement of the camera.
// It follows the player character as it moves.
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    // The position of the player.
    private Transform playerPos;

    // The position of the finish line.
    [SerializeField]
    private Transform finishLine;
    void Start()
    {
         // Find the player character by tag and get its position.
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
    }
    
    // Update is called once per frame
    void Update()
    {
        // If the player is between the start and finish lines,
        // move the camera to the player's position.
        if (playerPos.position.x > 0 && 
            playerPos.position.x < finishLine.position.x)
            transform.position = new Vector3 (
                playerPos.position.x, 
                transform.position.y, 
                transform.position.z);
    }

}