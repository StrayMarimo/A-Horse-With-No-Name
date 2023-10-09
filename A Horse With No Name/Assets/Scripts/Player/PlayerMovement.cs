// This script handles the movement of the player character.
// It listens for input from the user and moves the character accordingly.
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    // The leg parts of the player.
    [SerializeField] 
    private HingeJoint2D[] legs = new HingeJoint2D[12];

    // The speeds for each leg part.
    [SerializeField]
    private float[] hingeSpeeds = {200, 100, 50};

    // The key codes for each leg
    private readonly KeyCode[] keyCodes = {
        KeyCode.Q, KeyCode.W, KeyCode.O, KeyCode.P};
    // The motors for each leg part.
    private readonly JointMotor2D[] motors = new JointMotor2D[12];
     // The UI elements for each leg.
    private readonly Image[] keys = new Image[4];

    /// <summary>
    /// Initializes the motors and keys arrays.
    /// </summary>
    void Start()
    {
        PlayerPrefs.SetInt("isDead", 0);
        for (int i = 0; i < 12; i++) motors[i] = legs[i].motor;
        for (int i = 0; i < 4; i++)
            keys[i] = GameObject.FindGameObjectWithTag(
                keyCodes[i].ToString()).GetComponent<Image>();
        
    }

    /// <summary>
    /// Updates the player's movement based on input from the user.
    /// </summary>
    void Update()
    {
         // If the player is dead, stop listening for input.
        if (PlayerPrefs.GetInt("isDead") == 1)
        {
            OnKeyRelease();
            return;
        }
        // Listen for input from the user.
        for (int i = 0; i <= 3; i++)
            if (Input.GetKeyDown(keyCodes[i]))
            {
                // change color of key to let user know it's pressed
                keys[i].color = Color.red;
                // set motor speed for the corresponding leg part
                SetMotorSpeedPair(i * 3);
            }
        // Listen for key release.
        for (int i = 0; i <=3; i++)
            if (Input.GetKeyUp(keyCodes[i])) OnKeyRelease(i);
        
    }

    /// <summary>
    /// Moves a leg consisting of three parts
    /// upper has speed hingeSpeeds[0],
    /// middle has speed hingeSpeeds[1],
    /// lower has speed hingeSpeeds[2].
    /// </summary>
    /// <param name="index">index of first leg part.</param>
    private void SetMotorSpeedPair(int index){
        for (int i = index; i < index + 3; i++)
        {
            legs[i].useMotor = true;
            motors[i].motorSpeed = -hingeSpeeds[i - index];
            legs[i].motor = motors[i];
        }
    }

    /// <summary>
    /// Changes the color of the key at the specified index to white 
    /// and stops the corresponding leg parts' motors.
    /// </summary>
    /// <param name="index">The index of the key to release.</param>
    private void OnKeyRelease(int index){
        keys[index].color = Color.white;
        for(int i = index * 3; i < index * 3 + 3; i++)
            legs[i].useMotor = false;
    }

    /// <summary>
    /// Changes the color of all keys to white and stops all motors.
    /// called when the player dies.
    /// </summary>
    private void OnKeyRelease(){
        for (int i = 0; i <=3 ; i++) keys[i].color = Color.white;
        for(int i = 0; i < 12; i++) legs[i].useMotor = false; 
    }
}