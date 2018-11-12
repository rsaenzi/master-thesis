using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class FighterMotion : MonoBehaviour {

    // Components
    private Rigidbody body;

    // Input
    private readonly string verticalAxisName = "Vertical";     // FighterMotionVertical
    private readonly string horizontalAxisName = "Horizontal"; // FighterMotionVertical
    private float verticalAxisValue = 0;
    private float horizontalAxisValue = 0;

    // Turn Forces
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

    // Rotation Angles
    private Vector3 rotationVector = Vector3.zero;
    private Quaternion rotationQuaternion = Quaternion.identity;
    private readonly float interpolationSpeed = 1.5f;
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

        // Get the key/joystick input values
#if UNITY_EDITOR
        verticalAxisValue = Input.GetAxis(verticalAxisName);
        horizontalAxisValue = Input.GetAxis(horizontalAxisName);

# elif UNITY_IOS || UNITY_ANDROID
        verticalAxisValue = CrossPlatformInputManager.GetAxis(verticalAxisName);
        horizontalAxisValue = CrossPlatformInputManager.GetAxis(horizontalAxisName);
#else
        verticalAxisValue = Input.GetAxis(verticalAxisName);
        horizontalAxisValue = Input.GetAxis(horizontalAxisName);
#endif

        // We assume we do not need a rotation
        rotationVector = Vector3.zero;

        // Apply the force and calculate the rotation vector
        if (verticalAxisValue > 0) { // Up
            body.AddForce(turnTargetUp * verticalAxisValue, motionForceMode); // Applies a force vector in the direction of the desired motion
            rotationVector += rotationTargetUp * verticalAxisValue; // Set the rotation vector target
        }

        if (verticalAxisValue < 0) { // Down
            body.AddForce(turnTargetDown * -verticalAxisValue, motionForceMode);
            rotationVector += rotationTargetDown * -verticalAxisValue;
        }

        if (horizontalAxisValue < 0) { // Right
            body.AddForce(turnTargetRight * horizontalAxisValue, motionForceMode);
            rotationVector += rotationTargetRight * horizontalAxisValue;
        }

        if (horizontalAxisValue > 0) { // Left
            body.AddForce(turnTargetLeft * -horizontalAxisValue, motionForceMode);
            rotationVector += rotationTargetLeft * -horizontalAxisValue;
        }

        // Apply the rotation vector to the fighter
        rotationQuaternion = Quaternion.Euler(rotationVector);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotationQuaternion, interpolationSpeed * Time.deltaTime);
    }
}
