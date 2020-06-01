using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePanoramicCamera : MonoBehaviour
{
    public float rotationSpeed;

    void Update()
    {
        this.transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime, Space.World);
    }
}