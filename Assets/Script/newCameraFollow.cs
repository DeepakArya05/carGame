using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newCameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public Vector3 eulerRotation;
    public float damper;
    // Start is called before the first frame update
    void Start()
    {
        transform.eulerAngles = eulerRotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
            return;
        transform.position = Vector3.Lerp(transform.position, target.position + offset, damper * Time.deltaTime);
    }
}
