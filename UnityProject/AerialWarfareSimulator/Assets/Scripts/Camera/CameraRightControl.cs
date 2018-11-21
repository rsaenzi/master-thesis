using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRightControl : MonoBehaviour {

    // Distances
    private readonly float distanceToFighter = 15.0f;

    // Target to follow
    private Transform fighter;

    void Awake() {

        // Target to follow
        fighter = GameObject.Find("Fighter/CameraTarget").transform;
    }

    void LateUpdate() {
        this.transform.position = fighter.position + (Vector3.right * distanceToFighter);
    }
}
