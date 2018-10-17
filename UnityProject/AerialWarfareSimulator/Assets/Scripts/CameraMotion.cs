using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotion : MonoBehaviour {

    // Approach
    private Vector3 approachVector;
    private float approachSpeed = 25.0f;

    // Target to follow
    private Transform fighter;

    void Awake() {

        // Target to follow
        fighter = GameObject.Find("Fighter/CameraTarget").transform;
    }

    void Update() {

        // Always the camera is pointing toward the fighter
        this.transform.LookAt(fighter);

        // We can get a closer or farther view of the plane
        if(Input.GetKey(KeyCode.W)) {
            approachVector = Vector3.forward * Time.deltaTime * approachSpeed;
            this.transform.Translate(approachVector, Space.Self);
        }

        if(Input.GetKey(KeyCode.S)) {
            approachVector = Vector3.back * Time.deltaTime * approachSpeed;
            this.transform.Translate(approachVector, Space.Self);
        }
    }
}
