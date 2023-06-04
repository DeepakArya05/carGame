using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewCarScript : MonoBehaviour
{
    public Transform centeOfMass;

    public Transform FrontLeftWheel;
    public Transform FrontRightWheel;
    public Transform RearLeftWheel;
    public Transform RearRightWheel;

    public WheelCollider FrontLeftcollider;
    public WheelCollider FrontRightcollider;
    public WheelCollider RearLeftcollider;
    public WheelCollider RearRightcollider;

    
    public float moterTorque = 100f;
    public float maxSteer = 20f;
    private Rigidbody _rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.centerOfMass = centeOfMass.localPosition;
    }

    void FixedUpdate()
    {
        RearLeftcollider.motorTorque = Input.GetAxis("Vertical") * -moterTorque;
        RearRightcollider.motorTorque = Input.GetAxis("Vertical") * -moterTorque;

        FrontLeftcollider.steerAngle = Input.GetAxis("Horizontal")*maxSteer;
        FrontRightcollider.steerAngle = Input.GetAxis("Horizontal") * maxSteer;

    }

    // Update is called once per frame
    void Update()
    {
        var pos=Vector3.zero;
        var rot = Quaternion.identity;

        FrontLeftcollider.GetWorldPose(out pos, out rot);
        FrontLeftWheel.position = pos;
        FrontLeftWheel.rotation = rot;

        FrontRightcollider.GetWorldPose(out pos, out rot);
        FrontRightWheel.position = pos;
        FrontRightWheel.rotation = rot *Quaternion.Euler(0,180,0);

        RearLeftcollider.GetWorldPose(out pos, out rot);
        RearLeftWheel.position = pos;
        RearLeftWheel.rotation = rot ;

        RearRightcollider.GetWorldPose(out pos, out rot);
        RearRightWheel.position = pos;
        RearRightWheel.rotation = rot * Quaternion.Euler(0, 180, 0);
    }
}
