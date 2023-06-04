using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carScript3 : MonoBehaviour
{
    public Transform centerOfMass;
    public float motorTorque = 1500f;
    public float maxSteer = 20f;

    public float steer { get; set; }
    public float throttle { get; set; }

    private Rigidbody _rigidbody;
    private wheel[] wheels;
    // Start is called before the first frame update
    void Start()
    {
         wheels = GetComponentsInChildren<wheel>();
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.centerOfMass = centerOfMass.localPosition;
        
    }

    // Update is called once per frame
    void Update()
    {
        steer = gameManager.Instance.InputController.steerInput;
        throttle = gameManager.Instance.InputController.throttleInput;
        foreach(var wheel in wheels)
        {
            wheel.steerAngle = steer * maxSteer;
            wheel.torque = (-throttle) * motorTorque;
        }
    }
}
