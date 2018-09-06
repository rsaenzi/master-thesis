using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterSimpleMotion : MonoBehaviour {

    // Motion
    private float verticalSpeed = 18;
    private float horizontalSpeed = 15;
    private float forceValue = 25;
    private ForceMode mode = ForceMode.Acceleration;

    // Rotation
    private float rotationSpeed = 1f;
    private float horizontalRotation = 45;
    private float verticalRotation = 45;
    private Vector3 rotationVector = Vector3.zero;

	void Update () {

        rotationVector = Vector3.zero;

        if (Input.GetKey(KeyCode.UpArrow)) {
            this.GetComponent<Rigidbody>().AddForce(Vector3.up * forceValue, mode);
            rotationVector += new Vector3(-verticalRotation, 0, 0);
        }

        if (Input.GetKey(KeyCode.DownArrow)) {
            this.GetComponent<Rigidbody>().AddForce(Vector3.down * forceValue, mode);
            rotationVector += new Vector3(verticalRotation, 0, 0);
        }

        if (Input.GetKey(KeyCode.LeftArrow)){
            this.GetComponent<Rigidbody>().AddForce(Vector3.left * forceValue, mode);
            rotationVector += new Vector3(0, 0, horizontalRotation);
        }

        if (Input.GetKey(KeyCode.RightArrow)) {
            this.GetComponent<Rigidbody>().AddForce(Vector3.right * forceValue, mode);
            rotationVector += new Vector3(0, 0, -horizontalRotation);
        }

        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.Euler(rotationVector), rotationSpeed * Time.deltaTime);
    }
}
