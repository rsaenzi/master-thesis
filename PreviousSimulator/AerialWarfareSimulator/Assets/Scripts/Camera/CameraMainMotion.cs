using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class CameraMainMotion : MonoBehaviour {

    // Input
    private readonly string axisCameraDistance = "CameraDistance";
    private readonly string axisCameraRotationY = "CameraRotationY";
    private float axisValueCameraDistance = 0;
    private float axisValueCameraRotationY = 0;

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
    private Transform cameraTarget;

    void Awake() {

        // Target to follow
        cameraTarget = GameObject.Find("Fighter/CameraTarget").transform;

        // Approach Targets
        approachTargetGetClose = Vector3.forward * approachSpeedGetClose;
        approachTargetMoveAway = Vector3.back * approachSpeedMoveAway;
    }

    void Start() {

        // Always the camera is pointing toward the fighter
        this.transform.LookAt(cameraTarget);
    }

    void Update() {

        // Get the key/joystick input values
#if UNITY_EDITOR
        axisValueCameraDistance = Input.GetAxis(axisCameraDistance);
        axisValueCameraRotationY = Input.GetAxis(axisCameraRotationY);

# elif UNITY_IOS || UNITY_ANDROID
        axisValueCameraDistance = CrossPlatformInputManager.GetAxis(axisCameraDistance);
        axisValueCameraRotationY = CrossPlatformInputManager.GetAxis(axisCameraRotationY);
#else
        axisValueCameraDistance = Input.GetAxis(axisCameraDistance);
        axisValueCameraRotationY = Input.GetAxis(axisCameraRotationY);
#endif

        // Gets a closer or farther view of the fighter
        if (axisValueCameraDistance > 0) {

            // Calculates the z-distance between the camera and the fighter
            currentDistanceToFighter = Vector3.Distance(this.transform.position, cameraTarget.position);

            if (currentDistanceToFighter > minDistanceToFighter) {

                // Get close to the figther
                this.transform.Translate(approachTargetGetClose * Time.deltaTime * axisValueCameraDistance, Space.Self);
            }
        }

        if (axisValueCameraDistance < 0) {

            // Calculates the z-distance between the camera and the fighter
            currentDistanceToFighter = Vector3.Distance(this.transform.position, cameraTarget.position);

            if (currentDistanceToFighter < maxDistanceToFighter) {

                // Moves away from the figther
                this.transform.Translate(approachTargetMoveAway * Time.deltaTime * -axisValueCameraDistance, Space.Self);
            }
        }

        // Rotates the camera around the fighter
        if (axisValueCameraRotationY != 0) {
            this.transform.RotateAround(cameraTarget.transform.position, Vector3.up, rotationSpeed * Time.deltaTime * -axisValueCameraRotationY);
        }

        // Always the camera is pointing toward the fighter
        this.transform.LookAt(cameraTarget);
    }
}
