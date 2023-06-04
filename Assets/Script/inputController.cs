using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inputController : MonoBehaviour
{
    private string inputSteerAxis="Horizontal";
    private string inputThrottleAxis="Vertical";

    public float throttleInput { get; private set; }
    public float steerInput { get; private set; }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        steerInput = Input.GetAxis(inputSteerAxis);
        throttleInput = Input.GetAxis(inputThrottleAxis);
    }
}

