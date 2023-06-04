using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carScript : MonoBehaviour
{
   // private const string HORIZONTAL = "Horizontal";
    //private const string VERTICAL = "Vertical";


    private float currentBreakForce;
    private bool isBreaking;


    private float horizontalInput;
    private float verticalInput;

    private float currentSteerAngle;



    [SerializeField] private WheelCollider frontLeftWheelCollider;
    [SerializeField] private WheelCollider frontRightWheelCollider;
    [SerializeField] private WheelCollider rearLeftWheelCollider;
    [SerializeField] private WheelCollider rearRightWheelCollider;

    [SerializeField] private Transform frontLeftWheelTransform;
    [SerializeField] private Transform frontRightWheelTransform;
    [SerializeField] private Transform rearLeftWheelTransform;
    [SerializeField] private Transform rearRightWheelTransform;

    [SerializeField] private float moterForce;
    [SerializeField] private float breakForce;

    
    [SerializeField] private float maxSteeringAngle;

    private void Start()
    {
        
    }

    private void FixedUpdate()
    {
        GetInput();
        HandleMoter();
        HandleSteering();
        updateWheels();
    }

    private void GetInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        isBreaking = Input.GetKey(KeyCode.Space);
    }

    private void HandleMoter()
    {
        frontLeftWheelCollider.motorTorque = verticalInput * moterForce;
        frontRightWheelCollider.motorTorque = verticalInput * moterForce;
        
        currentBreakForce = isBreaking ? breakForce : 0f;
        if (isBreaking)
        {
            frontLeftWheelCollider.brakeTorque = currentBreakForce;
            frontRightWheelCollider.brakeTorque = currentBreakForce;

            rearLeftWheelCollider.brakeTorque = currentBreakForce;
            rearRightWheelCollider.brakeTorque = currentBreakForce;
        }
    }


    private void HandleSteering()
    {
        currentSteerAngle = maxSteeringAngle * horizontalInput;
        frontLeftWheelCollider.steerAngle = currentSteerAngle;
        frontRightWheelCollider.steerAngle = currentSteerAngle;
    }

    private void updateWheels()
    {
        updateSingleWheel(frontLeftWheelCollider, frontLeftWheelTransform);
        updateSingleWheel(frontRightWheelCollider, frontRightWheelTransform);
        updateSingleWheel(rearLeftWheelCollider, rearLeftWheelTransform);
        updateSingleWheel(rearRightWheelCollider, rearRightWheelTransform);
    }


    private void updateSingleWheel(WheelCollider wheelCollider,Transform wheelTransform)
    {
        Vector3 pos;
        Quaternion rot;
        wheelCollider.GetWorldPose(out pos, out rot);
        wheelTransform.rotation = rot;
        wheelTransform.position = pos;

    }
   




}
