using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterShooting : MonoBehaviour {

    // Components
    private AudioSource gatlingSound;

    // Input
    private readonly KeyCode shootGatlingKey = KeyCode.Space;
    private readonly KeyCode launchMissileKey = KeyCode.Return;

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

        // Starts the shooting sound when shoot key is pressed
        if(Input.GetKeyDown(shootGatlingKey)) {

            if(!gatlingSound.isPlaying) {
                gatlingSound.Play();
            }
        }

        // Stop the shooting sound if shooting key is released
        if(Input.GetKeyUp(shootGatlingKey)) {
            gatlingSound.Stop();
        }

        // Launch the missile
        if(Input.GetKeyDown(launchMissileKey)) {

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
