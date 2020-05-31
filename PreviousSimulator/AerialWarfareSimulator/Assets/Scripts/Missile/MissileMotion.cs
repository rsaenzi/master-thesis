using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileMotion : MonoBehaviour {

    // Components
    private AudioSource missileSound;

    // Motion
    private Vector3 motionVector;
    private readonly float motionSpeed = 50.0f;

    // Collider Activation
    private float initPositionZ = 0.0f;
    private bool safeDistanceReached = false;
    private float safeDistanceFromFighter = 15.0f;

    void Awake() {

        // Components
        missileSound = GameObject.Find(this.name + "/Sounds/LaunchSound").GetComponent<AudioSource>();
    }

    void Start() {

        // As soon as it is launched we play the launch sound
        missileSound.Play();

        // We store the init position in Z to determine when we should activate the collider
        // in order to avoid collision with fighter's colliders
        initPositionZ = this.transform.position.z;
    }

    void Update() {

        // Moves the missile forward continuosly
        motionVector = Vector3.forward * Time.deltaTime * motionSpeed;
        this.transform.Translate(motionVector, Space.Self);
    }

    void LateUpdate() {

        // If the missile is not away enough from the fighter
        if(!safeDistanceReached) {

            // If missile is far away enough from the fighter
            if(this.transform.position.z >= (initPositionZ + safeDistanceFromFighter)) {

                // This will prevent to reenable the collider
                safeDistanceReached = true;

                // Activates the collider to detect collisions with enemies
                this.GetComponent<CapsuleCollider>().isTrigger = false;
            }
        }
    }
}
