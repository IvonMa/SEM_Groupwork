using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundHandler : MonoBehaviour
{
    private Vector3 _rotation_centre;
    private float rotationSpeed = 0.03f;
    
    void Start()
    {
        
        _rotation_centre = new Vector3(0f, -5f, 0f);
        transform.localScale = new Vector3(1.3f,1.3f,1f);
        transform.position = new Vector3(0f,-5f,0f);
    }


    void Update()
    {
        transform.RotateAround(_rotation_centre, Vector3.forward, rotationSpeed);
    }
}