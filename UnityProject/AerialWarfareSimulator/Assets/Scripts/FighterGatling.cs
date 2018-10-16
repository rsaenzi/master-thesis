using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterGatling : MonoBehaviour {

    // Components
    private AudioSource gatlingSound;

    // Input
    private readonly KeyCode shootKey = KeyCode.Space;

    void Awake() {

        // Components
        gatlingSound = GameObject.Find("Sounds/Gatling").GetComponent<AudioSource>();
    }

    void Update() {

        // Starts the shooting sound when shoot key is pressed
        if(Input.GetKeyDown(shootKey)) {

            if(!gatlingSound.isPlaying) {
                gatlingSound.Play();
            }
        }

        // Stop the shooting sound if shooting key is released
        if(Input.GetKeyUp(shootKey)) {
            gatlingSound.Stop();
        }
    }
}
