using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    private GameObject KeySprite;
    public HingeJoint2D[] legs = new HingeJoint2D[12];
    private JointMotor2D[] motors = new JointMotor2D[12];
    private Image[] keys = new Image[4];
    
    public float hingeSpeed = 400;
    public float hingeSpeed2 = 250;
    public float hingeSpeed3 = 100;
    public Transform body;
    public Transform finishLine;
    public bool isDead = false;
    private KeyCode[] keyCodes = {KeyCode.Q, KeyCode.W, KeyCode.O, KeyCode.P};

    /// <summary>
    /// Initializes the motors and keys arrays.
    /// </summary>
    void Start()
    {
        for (int i = 0; i < 12; i++)
        {
            motors[i] = legs[i].motor;
        }
        for (int i = 0; i < 4; i++)
        {
            keys[i] = GameObject.FindGameObjectWithTag(keyCodes[i].ToString()).GetComponent<Image>();
        }
    }

    /// <summary>
    /// Updates the player's movement based on input from the user.
    /// </summary>
    void Update()
    {
        if (isDead)
        {
            onKeyRelease();
            return;
        }
        for (int i = 0; i <= 3; i++)
        {
            if (Input.GetKeyDown(keyCodes[i]))
            {
                keys[i].color = Color.red;
                setMotorSpeedPair(i * 3);
            }
        }
        for (int i = 0; i <=3; i++)
        {
            if (Input.GetKeyUp(keyCodes[i]))
            {
                onKeyRelease(i);
            }
        }
    }

    /// <summary>
    /// Sets the motor speed for a a leg with 3 parts
    /// </summary>
    /// <param name="index">The index of the first leg in the group.</param>
    private void setMotorSpeedPair(int index){
        legs[index].useMotor = true;
        legs[index + 1].useMotor = true;
        legs[index + 2].useMotor = true;
        motors[index].motorSpeed = -hingeSpeed;
        motors[index + 1].motorSpeed = -hingeSpeed2;
        motors[index + 2].motorSpeed = -hingeSpeed3;
        legs[index].motor = motors[index];
        legs[index + 1].motor = motors[index + 1];
        legs[index + 2].motor = motors[index + 2];
    }



    /// <summary>
    /// Changes the color of the key at the specified index to white 
    /// and stops the corresponding leg parts' motors.
    /// </summary>
    /// <param name="index">The index of the key to release.</param>
    private void onKeyRelease(int index){
        keys[index].color = Color.white;
        for(int i = index * 3; i < index * 3 + 3; i++)
        {
            legs[i].useMotor = false;
        }
    }

    /// <summary>
    /// Handles the release of all keys.
    /// </summary>
    private void onKeyRelease(){
        for (int i = 0; i <=3 ; i++){
            keys[i].color = Color.white;
        }
        for(int i = 0; i < 12; i++)
        {
            legs[i].useMotor = false;
        }
    }
}