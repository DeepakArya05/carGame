using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wheel : MonoBehaviour
{
    public bool steer;
    public bool inverSteer;
    public bool power;

    public float steerAngle { get; set; }
    public float torque { get; set; }

    private WheelCollider wheelCollider;
    private Transform wheelTransform;
    // Start is called before the first frame update
    void Start()
    {
        wheelCollider = GetComponentInChildren<WheelCollider>();
        wheelTransform = GetComponentInChildren<MeshCollider>().GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        //var pos = Vector3.zero;
        //var rot = Quaternion.identity;
        this.wheelCollider.GetWorldPose(out Vector3 pos, out Quaternion rot);
        this.wheelTransform.position = pos;
        this.wheelTransform.rotation = rot;
    }

    private void FixedUpdate()
    {
        if(steer)
        {
            wheelCollider.steerAngle = steerAngle * (inverSteer ? -1 : 1);
        }
        if(power)
        {
            wheelCollider.motorTorque = torque;
            
        }
    }
}
