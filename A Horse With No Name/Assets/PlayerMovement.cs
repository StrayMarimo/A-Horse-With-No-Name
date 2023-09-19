using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public HingeJoint2D FLA;
    public HingeJoint2D FRA;
    public HingeJoint2D FLB;
    public HingeJoint2D FRB;
    public HingeJoint2D FLC;
    public HingeJoint2D FRC;
    public HingeJoint2D BLA;
    public HingeJoint2D BLB;
    public HingeJoint2D BLC;
    public HingeJoint2D BRA;
    public HingeJoint2D BRB;
    public HingeJoint2D BRC;

    private JointMotor2D FLAMotorRef;
    private JointMotor2D FLBMotorRef;
    private JointMotor2D FLCMotorRef;
    private JointMotor2D FRAMotorRef;
    private JointMotor2D FRBMotorRef;
    private JointMotor2D FRCMotorRef;
    private JointMotor2D BLAMotorRef;
    private JointMotor2D BLBMotorRef;
    private JointMotor2D BLCMotorRef;
    private JointMotor2D BRAMotorRef;
    private JointMotor2D BRBMotorRef;
    private JointMotor2D BRCMotorRef;
    
    void Start()
    {
        FLAMotorRef = FLA.motor;
        FLBMotorRef = FLB.motor;
        FLCMotorRef = FLC.motor;
        FRAMotorRef = FRA.motor;
        FRBMotorRef = FRB.motor;
        FRCMotorRef = FRC.motor;
        BLAMotorRef = BLA.motor;
        BLBMotorRef = BLB.motor;
        BLCMotorRef = BLC.motor;
        BRAMotorRef = BRA.motor;
        BRBMotorRef = BRB.motor;
        BRCMotorRef = BRC.motor;
    }

    public float hingeSpeed = 40;
    
    void Update()
    {
        if(Input.GetKey(KeyCode.Q))
        {
            FLA.useMotor = true;
            BRA.useMotor = true;
            FRA.useMotor = true;
            BLA.useMotor = true;

            FLAMotorRef.motorSpeed = hingeSpeed;
            BRAMotorRef.motorSpeed = hingeSpeed;
            FRAMotorRef.motorSpeed = -hingeSpeed;
            BLAMotorRef.motorSpeed = -hingeSpeed;

            FLA.motor = FLAMotorRef;
            BRA.motor = BRAMotorRef;
            FRA.motor = FRAMotorRef;
            BLA.motor = BLAMotorRef;
        }

        else if(Input.GetKey(KeyCode.W))
        {
            FLB.useMotor = true;
            BRB.useMotor = true;
            FRB.useMotor = true;
            BLB.useMotor = true;

            FLBMotorRef.motorSpeed = hingeSpeed;
            BRBMotorRef.motorSpeed = hingeSpeed;
            FRBMotorRef.motorSpeed = -hingeSpeed;
            BLBMotorRef.motorSpeed = -hingeSpeed;

            FLB.motor = FLBMotorRef;
            BRB.motor = BRBMotorRef;
            FRB.motor = FRBMotorRef;
            BLB.motor = BLBMotorRef;
        }

        else if(Input.GetKey(KeyCode.E))
        {
            FLC.useMotor = true;
            BRC.useMotor = true;
            FRC.useMotor = true;
            BLC.useMotor = true;

            FLCMotorRef.motorSpeed = hingeSpeed;
            BRCMotorRef.motorSpeed = hingeSpeed;
            FRCMotorRef.motorSpeed = -hingeSpeed;
            BLCMotorRef.motorSpeed = -hingeSpeed;

            FLC.motor = FLCMotorRef;
            BRC.motor = BRCMotorRef;
            FRC.motor = FRCMotorRef;
            BLC.motor = BLCMotorRef;
        }
        else 
        {
            FLA.useMotor = false;
            BRA.useMotor = false;
            FRA.useMotor = false;
            BLA.useMotor = false;
        }
    }
}
