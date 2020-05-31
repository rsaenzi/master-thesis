using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTopControl : MonoBehaviour {

    // Distances
    private readonly float distanceToFighter = 10.0f;

    // Target to follow
    private Transform cameraTarget;

    void Awake() {

        // Target to follow
        cameraTarget = GameObject.Find("Fighter/CameraTarget").transform;
    }

    void LateUpdate() {
        this.transform.position = cameraTarget.position + (Vector3.up * distanceToFighter);
    }
}
