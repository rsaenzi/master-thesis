using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class CameraMotion : MonoBehaviour {

    // Approach Speeds
    private float approachSpeedGetClose = 50.0f;
    private float approachSpeedMoveAway = 40.0f;

    // Approach Targets
    private Vector3 approachTargetGetClose;
    private Vector3 approachTargetMoveAway;

    // Distances
    private float currentDistanceToFighter = 0.0f;
    private float minDistanceToFighter = 20.0f;
    private float maxDistanceToFighter = 100.0f;

    // Target to follow
    private Transform fighter;

    // Input
    private readonly string verticalAxisName = "Mouse Y"; // CameraDistance
    private float verticalAxisValue = 0;

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

# elif UNITY_IOS || UNITY_ANDROID
        verticalAxisValue = CrossPlatformInputManager.GetAxis(verticalAxisName);
#else
        verticalAxisValue = Input.GetAxis(verticalAxisName);
#endif

        // We can get a closer or farther view of the fighter
        if (verticalAxisValue > 0) {

            // Calculates the z-distance between the camera and the fighter
            currentDistanceToFighter = Mathf.Abs(this.transform.position.z - fighter.position.z);

            if (currentDistanceToFighter > minDistanceToFighter) {

                // Get close to the figther
                this.transform.Translate(approachTargetGetClose * Time.deltaTime * verticalAxisValue, Space.Self);
            }
        }

        if (verticalAxisValue < 0) {

            // Calculates the z-distance between the camera and the fighter
            currentDistanceToFighter = Mathf.Abs(this.transform.position.z - fighter.position.z);

            if (currentDistanceToFighter < maxDistanceToFighter) {

                // Moves away from the figther
                this.transform.Translate(approachTargetMoveAway * Time.deltaTime * -verticalAxisValue, Space.Self);
            }
        }

        // Always the camera is pointing toward the fighter
        this.transform.LookAt(fighter);
    }
}
