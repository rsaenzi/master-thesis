using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class CameraMotion : MonoBehaviour {

    // Input
    private readonly string verticalAxisName = "CameraDistance";
    private readonly string horizontalAxisName = "CameraRotation";
    private float verticalAxisValue = 0;
    private float horizontalAxisValue = 0;

    // Approach Speeds
    private readonly float approachSpeedGetClose = 50.0f;
    private readonly float approachSpeedMoveAway = 40.0f;

    // Approach Targets
    private Vector3 approachTargetGetClose;
    private Vector3 approachTargetMoveAway;

    // Rotation Speed
    private readonly float rotationSpeed = 60.0f;

    // Distances
    private float currentDistanceToFighter = 0.0f;
    private readonly float minDistanceToFighter = 14.0f;
    private readonly float maxDistanceToFighter = 100.0f;

    // Target to follow
    private Transform fighter;

    void Awake() {

        // Target to follow
        fighter = GameObject.Find("Fighter/CameraTarget").transform;

        // Approach Targets
        approachTargetGetClose = Vector3.forward * approachSpeedGetClose;
        approachTargetMoveAway = Vector3.back * approachSpeedMoveAway;
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

        // Gets a closer or farther view of the fighter
        if (verticalAxisValue > 0) {

            // Calculates the z-distance between the camera and the fighter
            currentDistanceToFighter = Vector3.Distance(this.transform.position, fighter.position);
            //currentDistanceToFighter = Mathf.Abs(this.transform.position.z - fighter.position.z);

            if (currentDistanceToFighter > minDistanceToFighter) {

                // Get close to the figther
                this.transform.Translate(approachTargetGetClose * Time.deltaTime * verticalAxisValue, Space.Self);
            }
        }

        if (verticalAxisValue < 0) {

            // Calculates the z-distance between the camera and the fighter
            currentDistanceToFighter = Vector3.Distance(this.transform.position, fighter.position);
            //currentDistanceToFighter = Mathf.Abs(this.transform.position.z - fighter.position.z);

            if (currentDistanceToFighter < maxDistanceToFighter) {

                // Moves away from the figther
                this.transform.Translate(approachTargetMoveAway * Time.deltaTime * -verticalAxisValue, Space.Self);
            }
        }

        // Rotates the camera around the fighter
        if (horizontalAxisValue != 0) {
            this.transform.RotateAround(fighter.transform.position, Vector3.up, rotationSpeed * Time.deltaTime * -horizontalAxisValue);
        }

        // Always the camera is pointing toward the fighter
        this.transform.LookAt(fighter);
    }
}
