using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterSimpleMotion : MonoBehaviour {

    // Components
    private Rigidbody body;

    // Motion
    private readonly ForceMode mode = ForceMode.Acceleration;
    private readonly float motionForceUp = 20;
    private readonly float motionForceDown = 30;
    private readonly float motionForceLeft = 30;
    private readonly float motionForceRight = 30;

    // Motion Targets
    private Vector3 motionTargetUp;
    private Vector3 motionTargetDown;
    private Vector3 motionTargetLeft;
    private Vector3 motionTargetRight;

    // Rotation
    private Vector3 rotationVector = Vector3.zero;
    private readonly float interpolationSpeed = 1.2f;
    private readonly float rotationSpeedUp = 50;
    private readonly float rotationSpeedDown = 45;
    private readonly float rotationSpeedLeft = 45;
    private readonly float rotationSpeedRight = 45;

    // Rotation Targets
    private Vector3 rotationTargetUp;
    private Vector3 rotationTargetDown;
    private Vector3 rotationTargetLeft;
    private Vector3 rotationTargetRight;

    void Awake() {

        // Components
        body = GetComponent<Rigidbody>();

        // Motion Targets
        motionTargetUp = Vector3.up * motionForceUp;
        motionTargetDown = Vector3.down * motionForceDown;
        motionTargetLeft = Vector3.left * motionForceLeft;
        motionTargetRight = Vector3.right * motionForceRight;

        // Rotation Targets
        rotationTargetUp = new Vector3(-rotationSpeedUp, 0, 0);
        rotationTargetDown = new Vector3(rotationSpeedDown, 0, 0);
        rotationTargetLeft = new Vector3(0, 0, rotationSpeedLeft); ;
        rotationTargetRight = new Vector3(0, 0, -rotationSpeedRight);
    }

    void Update() {

        rotationVector = Vector3.zero;

        if(Input.GetKey(KeyCode.UpArrow)) {
            body.AddForce(motionTargetUp, mode);
            rotationVector += rotationTargetUp;
        }

        if(Input.GetKey(KeyCode.DownArrow)) {
            body.AddForce(motionTargetDown, mode);
            rotationVector += rotationTargetDown;
        }

        if(Input.GetKey(KeyCode.LeftArrow)) {
            body.AddForce(motionTargetLeft, mode);
            rotationVector += rotationTargetLeft;
        }

        if(Input.GetKey(KeyCode.RightArrow)) {
            body.AddForce(motionTargetRight, mode);
            rotationVector += rotationTargetRight;
        }

        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(rotationVector), interpolationSpeed * Time.deltaTime);
    }
}
