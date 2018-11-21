using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileCollision : MonoBehaviour {

    // Components
    private AudioSource explosionSound;

    void Awake() {

        // Components
        explosionSound = GameObject.Find(this.name + "/Sounds/ExplosionSound").GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other) {

        // If the missiles hits an enemy
        if(other.gameObject.tag == "Enemy") {

            // We play the explosion sound
            explosionSound.Play();

            // Destroy the enemy
            Destroy(other.gameObject.transform.parent.gameObject);

            // TODO: We must destroy de missile body, but keeping the explosion sound
        }
    }
}
