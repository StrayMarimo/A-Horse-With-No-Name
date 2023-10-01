using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private GameObject KeySprite;
    public HingeJoint2D FLA;
    public HingeJoint2D FRA;
    public HingeJoint2D BLA;
    public HingeJoint2D BRA;
    public HingeJoint2D FLB;
    public HingeJoint2D FRB;
    public HingeJoint2D BLB;
    public HingeJoint2D BRB;
    public HingeJoint2D FLC;
    public HingeJoint2D FRC;
    public HingeJoint2D BLC;
    public HingeJoint2D BRC;

    private JointMotor2D FLAMotorRef;
    private JointMotor2D FRAMotorRef;
    private JointMotor2D BLAMotorRef;
    private JointMotor2D BRAMotorRef;
    private JointMotor2D FLBMotorRef;
    private JointMotor2D FRBMotorRef;
    private JointMotor2D BLBMotorRef;
    private JointMotor2D BRBMotorRef;
    private JointMotor2D FLCMotorRef;
    private JointMotor2D FRCMotorRef;
    private JointMotor2D BLCMotorRef;
    private JointMotor2D BRCMotorRef;
    
    public float hingeSpeed = 40;
    public float hingeSpeed2 = 20;
    public float hingeSpeed3 = 5;
    void Start()
    {
        
        FLAMotorRef = FLA.motor;
        FRAMotorRef = FRA.motor;
        BLAMotorRef = BLA.motor;
        BRAMotorRef = BRA.motor;
        FLBMotorRef = FLB.motor;
        FRBMotorRef = FRB.motor;
        BLBMotorRef = BLB.motor;
        BRBMotorRef = BRB.motor;
        FLCMotorRef = FLC.motor;
        FRCMotorRef = FRC.motor;
        BLCMotorRef = BLC.motor;
        BRCMotorRef = BRC.motor;
    }

    
    void Update()
    {
        if(Input.GetKey(KeyCode.Q))
        {
            onKeyPress("Q");
            FLA.useMotor = true;
            BRA.useMotor = true;
            FRA.useMotor = true;
            BLA.useMotor = true;

            FLB.useMotor = true;
            BRB.useMotor = true;
            FRB.useMotor = true;
            BLB.useMotor = true;

            FLC.useMotor = true;
            BRC.useMotor = true;
            FRC.useMotor = true;
            BLC.useMotor = true;

            FLAMotorRef.motorSpeed = -hingeSpeed;
            BRAMotorRef.motorSpeed = -hingeSpeed;
            FRAMotorRef.motorSpeed = hingeSpeed3;
            BLAMotorRef.motorSpeed = hingeSpeed3;

            FLBMotorRef.motorSpeed = -hingeSpeed2;
            BRBMotorRef.motorSpeed = -hingeSpeed2;
            FRBMotorRef.motorSpeed = hingeSpeed3;
            BLBMotorRef.motorSpeed = hingeSpeed3;

            FLCMotorRef.motorSpeed = -hingeSpeed3;
            BRCMotorRef.motorSpeed = -hingeSpeed3;
            FRCMotorRef.motorSpeed = hingeSpeed3;
            BLCMotorRef.motorSpeed = hingeSpeed3;

            FLA.motor = FLAMotorRef;
            BRA.motor = BRAMotorRef;
            FRA.motor = FRAMotorRef;
            BLA.motor = BLAMotorRef;

            FLB.motor = FLBMotorRef;
            BRB.motor = BRBMotorRef;
            FRB.motor = FRBMotorRef;
            BLB.motor = BLBMotorRef;

            FLC.motor = FLCMotorRef;
            BRC.motor = BRCMotorRef;
            FRC.motor = FRCMotorRef;
            BLC.motor = BLCMotorRef;
            
        }

        else if(Input.GetKey(KeyCode.W))
        {
            onKeyPress("W");
            FLB.useMotor = true;
            BRB.useMotor = true;
            FRB.useMotor = true;
            BLB.useMotor = true;

            FLC.useMotor = true;
            BRC.useMotor = true;
            FRC.useMotor = true;
            BLC.useMotor = true;

            FLBMotorRef.motorSpeed = -hingeSpeed;
            BRBMotorRef.motorSpeed = -hingeSpeed;
            FRBMotorRef.motorSpeed = hingeSpeed3;
            BLBMotorRef.motorSpeed = hingeSpeed3;

            FLCMotorRef.motorSpeed = -hingeSpeed2;
            BRCMotorRef.motorSpeed = -hingeSpeed2;
            FRCMotorRef.motorSpeed = hingeSpeed3;
            BLCMotorRef.motorSpeed = hingeSpeed3;

            FLB.motor = FLBMotorRef;
            BRB.motor = BRBMotorRef;
            FRB.motor = FRBMotorRef;
            BLB.motor = BLBMotorRef;

            FLC.motor = FLCMotorRef;
            BRC.motor = BRCMotorRef;
            FRC.motor = FRCMotorRef;
            BLC.motor = BLCMotorRef;
            
        }
        else if(Input.GetKey(KeyCode.E))
        {
            onKeyPress("E");
            FLC.useMotor = true;
            BRC.useMotor = true;
            FRC.useMotor = true;
            BLC.useMotor = true;

            FLCMotorRef.motorSpeed = -hingeSpeed;
            BRCMotorRef.motorSpeed = -hingeSpeed;
            FRCMotorRef.motorSpeed = hingeSpeed3;
            BLCMotorRef.motorSpeed = hingeSpeed3;

            FLC.motor = FLCMotorRef;
            BRC.motor = BRCMotorRef;
            FRC.motor = FRCMotorRef;
            BLC.motor = BLCMotorRef;
            
        }

        else if(Input.GetKey(KeyCode.I))
        {
            onKeyPress("I");
            FRA.useMotor = true;
            BLA.useMotor = true;
            FLA.useMotor = true;
            BRA.useMotor = true;

            FRB.useMotor = true;
            BLB.useMotor = true;
            FLB.useMotor = true;
            BRB.useMotor = true;

            FRC.useMotor = true;
            BLC.useMotor = true;
            FLC.useMotor = true;
            BRC.useMotor = true;

            FRAMotorRef.motorSpeed = -hingeSpeed;
            BLAMotorRef.motorSpeed = -hingeSpeed;
            FLAMotorRef.motorSpeed = hingeSpeed3;
            BRAMotorRef.motorSpeed = hingeSpeed3;

            FRBMotorRef.motorSpeed = -hingeSpeed2;
            BLBMotorRef.motorSpeed = -hingeSpeed2;
            FLBMotorRef.motorSpeed = hingeSpeed3;
            BRBMotorRef.motorSpeed = hingeSpeed3;

            FRCMotorRef.motorSpeed = -hingeSpeed3;
            BLCMotorRef.motorSpeed = -hingeSpeed3;
            FLCMotorRef.motorSpeed = hingeSpeed3;
            BRCMotorRef.motorSpeed = hingeSpeed3;


            FRA.motor = FRAMotorRef;
            BLA.motor = BLAMotorRef;
            FLA.motor = FLAMotorRef;
            BRA.motor = BRAMotorRef;

            FRB.motor = FRBMotorRef;
            BLB.motor = BLBMotorRef;
            FLB.motor = FLBMotorRef;
            BRB.motor = BRBMotorRef;

            FRC.motor = FRCMotorRef;
            BLC.motor = BLCMotorRef;
            FLC.motor = FLCMotorRef;
            BRC.motor = BRCMotorRef;
            
        }
        else if(Input.GetKey(KeyCode.O))
        {
            onKeyPress("O");
            FRB.useMotor = true;
            BLB.useMotor = true;
            FLB.useMotor = true;
            BRB.useMotor = true;

            FRC.useMotor = true;
            BLC.useMotor = true;
            FLC.useMotor = true;
            BRC.useMotor = true;

            FRBMotorRef.motorSpeed = -hingeSpeed;
            BLBMotorRef.motorSpeed = -hingeSpeed;
            FLBMotorRef.motorSpeed = hingeSpeed3;
            BRBMotorRef.motorSpeed = hingeSpeed3;

            FRCMotorRef.motorSpeed = -hingeSpeed2;
            BLCMotorRef.motorSpeed = -hingeSpeed2;
            FLCMotorRef.motorSpeed = hingeSpeed3;
            BRCMotorRef.motorSpeed = hingeSpeed3;

            FRB.motor = FRBMotorRef;
            BLB.motor = BLBMotorRef;
            FLB.motor = FLBMotorRef;
            BRB.motor = BRBMotorRef;

            FRC.motor = FRCMotorRef;
            BLC.motor = BLCMotorRef;
            FLC.motor = FLCMotorRef;
            BRC.motor = BRCMotorRef;
            
        }

        else if(Input.GetKey(KeyCode.P))
        {
            onKeyPress("P");
            FRC.useMotor = true;
            BLC.useMotor = true;
            FLC.useMotor = true;
            BRC.useMotor = true;

            FRCMotorRef.motorSpeed = -hingeSpeed;
            BLCMotorRef.motorSpeed = -hingeSpeed;
            FLCMotorRef.motorSpeed = hingeSpeed3;
            BRCMotorRef.motorSpeed = hingeSpeed3;

            FRC.motor = FRCMotorRef;
            BLC.motor = BLCMotorRef;
            FLC.motor = FLCMotorRef;
            BRC.motor = BRCMotorRef;
            
        }

        else {
        
            FLA.useMotor = false;
            FRA.useMotor = false;
            BLA.useMotor = false;
            BRA.useMotor = false;
            FLB.useMotor = false;
            FRB.useMotor = false;
            BLB.useMotor = false;
            BRB.useMotor = false;
            FLC.useMotor = false;
            FRC.useMotor = false;
            BLC.useMotor = false;
            BRC.useMotor = false;
            onKeyRelease("Q");
            onKeyRelease("W");
            onKeyRelease("E");
            onKeyRelease("I");
            onKeyRelease("O");
            onKeyRelease("P");

        }
        
    }

    void onKeyPress(string key){
        KeySprite = GameObject.FindGameObjectWithTag(key);
        KeySprite.GetComponent<SpriteRenderer>().color = Color.red;
    }

    void onKeyRelease(string key){
        KeySprite = GameObject.FindGameObjectWithTag(key);
        KeySprite.GetComponent<SpriteRenderer>().color = Color.white;
    }



}
