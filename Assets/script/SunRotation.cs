using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunRotation : MonoBehaviour
{
    public float rotationSpeed = 1f;
    

    void Update()
    {
        // Making the sun keep rotating based on a given speed around its own center
        transform.RotateAround(transform.position, Vector3.forward, rotationSpeed);
    }
}