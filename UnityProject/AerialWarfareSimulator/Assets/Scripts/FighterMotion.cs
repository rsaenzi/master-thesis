using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterMotion : MonoBehaviour {

    // Components
    private Rigidbody body;

    // Input
    private KeyCode goUpKey = KeyCode.UpArrow;
    private KeyCode goDownKey = KeyCode.DownArrow;
    private KeyCode goLeftKey = KeyCode.LeftArrow;
    private KeyCode goRightKey = KeyCode.RightArrow;

    // Turn
    private readonly ForceMode motionForceMode = ForceMode.Acceleration;
    private readonly float turnForceUp = 25;
    private readonly float turnForceDown = 35;
    private readonly float turnForceLeft = 40;
    private readonly float turnForceRight = 40;

    // Turn Targets
    private Vector3 turnTargetUp;
    private Vector3 turnTargetDown;
    private Vector3 turnTargetLeft;
    private Vector3 turnTargetRight;

    // Rotation
    private Vector3 rotationVector = Vector3.zero;
    private Quaternion rotationQuaternion = Quaternion.identity;
    private readonly float interpolationSpeed = 1.2f;
    private readonly float rotationAngleUp = 50;
    private readonly float rotationAngleDown = 40;
    private readonly float rotationAngleLeft = 60;
    private readonly float rotationAngleRight = 60;

    // Rotation Targets
    private Vector3 rotationTargetUp;
    private Vector3 rotationTargetDown;
    private Vector3 rotationTargetLeft;
    private Vector3 rotationTargetRight;

    void Awake() {

        // Components
        body = GetComponent<Rigidbody>();

        // Turn Targets
        turnTargetUp = Vector3.up * turnForceUp;
        turnTargetDown = Vector3.down * turnForceDown;
        turnTargetLeft = Vector3.left * turnForceLeft;
        turnTargetRight = Vector3.right * turnForceRight;

        // Rotation Targets
        rotationTargetUp = new Vector3(-rotationAngleUp, 0, 0);
        rotationTargetDown = new Vector3(rotationAngleDown, 0, 0);
        rotationTargetLeft = new Vector3(0, 0, rotationAngleLeft);
        rotationTargetRight = new Vector3(0, 0, -rotationAngleRight);
    }

    void Update() {

        // We assume we do not need a rotation
        rotationVector = Vector3.zero;

        // If any motion key is pressed...
        if(Input.GetKey(goUpKey)) {

            // Applies a force vector in the direction of the desired motion
            body.AddForce(turnTargetUp, motionForceMode);

            // Set the rotation vector target
            rotationVector += rotationTargetUp;
        }

        if(Input.GetKey(goDownKey)) {
            body.AddForce(turnTargetDown, motionForceMode);
            rotationVector += rotationTargetDown;
        }

        if(Input.GetKey(goLeftKey)) {
            body.AddForce(turnTargetLeft, motionForceMode);
            rotationVector += rotationTargetLeft;
        }

        if(Input.GetKey(goRightKey)) {
            body.AddForce(turnTargetRight, motionForceMode);
            rotationVector += rotationTargetRight;
        }

        // Apply the rotation vector to the fighter
        rotationQuaternion = Quaternion.Euler(rotationVector);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotationQuaternion, interpolationSpeed * Time.deltaTime);
    }
}
