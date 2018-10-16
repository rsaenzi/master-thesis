using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotion : MonoBehaviour {

    // Motion
    private Vector3 motionVector;
    private float motionSpeed = 20.0f;

    // Target to follow
    private Transform fighter;

    void Awake() {

        // Target to follow
        fighter = GameObject.Find("Fighter").transform;
    }

    void Update() {

        // Always the camera is pointing toward the fighter
        this.transform.LookAt(fighter);

        // We can get a closer or farther view of the plane
        if(Input.GetKey(KeyCode.W)) {
            motionVector = Vector3.forward * Time.deltaTime * motionSpeed;
            this.transform.Translate(motionVector, Space.Self);
        }

        if(Input.GetKey(KeyCode.S)) {
            motionVector = Vector3.back * Time.deltaTime * motionSpeed;
            this.transform.Translate(motionVector, Space.Self);
        }
    }
}
