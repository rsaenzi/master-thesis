using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class FighterShooting : MonoBehaviour {

    // Components
    private AudioSource gatlingSound;

    // Input
    private readonly string shootGatlingButtonName = "Fire1";
    private readonly string launchMissileButtonName = "Fire2";
    private bool shootGatlingButtonUp = false;
    private bool shootGatlingButtonDown = false;
    private bool launchMissileButtonDown = false;

    // Prefabs
    private GameObject missilePrefab;

    // Shoot Pivots
    private bool rightPivotUsed = true;
    private GameObject missilePivotLeft;
    private GameObject missilePivotRight;

    // Containers
    private GameObject launchedMissilesContainer;

    void Awake() {

        // Components
        gatlingSound = GameObject.Find("Sounds/GatlingShooting").GetComponent<AudioSource>();

        // Prefabs
        missilePrefab = Resources.Load("Prefabs/Missile") as GameObject;

        // Shoot Pivots
        missilePivotLeft = GameObject.Find(this.name + "/ShootPivots/MissileLeft");
        missilePivotRight = GameObject.Find(this.name + "/ShootPivots/MissileRight");

        // Containers
        launchedMissilesContainer = GameObject.Find("LaunchedMissiles");
    }

    void Update() {

        // Get the key/joystick input values
#if UNITY_EDITOR
        shootGatlingButtonUp = Input.GetButtonUp(shootGatlingButtonName);
        shootGatlingButtonDown = Input.GetButtonDown(shootGatlingButtonName);
        launchMissileButtonDown = Input.GetButtonDown(launchMissileButtonName);

# elif UNITY_IOS || UNITY_ANDROID
        shootGatlingButtonUp = CrossPlatformInputManager.GetButtonUp(shootGatlingButtonName);
        shootGatlingButtonDown = CrossPlatformInputManager.GetButtonDown(shootGatlingButtonName);
        launchMissileButtonDown = CrossPlatformInputManager.GetButtonDown(launchMissileButtonName);
#else
        shootGatlingButtonUp = Input.GetButtonUp(shootGatlingButtonName);
        shootGatlingButtonDown = Input.GetButtonDown(shootGatlingButtonName);
        launchMissileButtonDown = Input.GetButtonDown(launchMissileButtonName);
#endif

        // Starts the shooting sound when shoot key is pressed
        if(shootGatlingButtonDown) {

            if(!gatlingSound.isPlaying) {
                gatlingSound.Play();
            }
        }

        // Stop the shooting sound if shooting key is released
        if(shootGatlingButtonUp) {
            gatlingSound.Stop();
        }

        // Launch the missile
        if(launchMissileButtonDown) {

            // Creates a copy of missile prefab inside the launch pivot for missiles
            GameObject newMissile = Instantiate(missilePrefab, Vector3.zero, this.transform.rotation);

            // Determines which launch pivot is going to be used
            if(rightPivotUsed) {

                newMissile.transform.SetParent(missilePivotRight.transform);
                rightPivotUsed = false;

            } else {
                newMissile.transform.SetParent(missilePivotLeft.transform);
                rightPivotUsed = true;
            }

            // Move the missil to that pivot
            newMissile.transform.localPosition = Vector3.zero;

            // To keep the scene organized we insert the missile into a container
            newMissile.transform.SetParent(launchedMissilesContainer.transform);
            newMissile.name = "Missile";

            // After 10 seconds we destroy the missile
            Destroy(newMissile, 30);
        }
    }
}
