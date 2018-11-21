using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FigtherLines : MonoBehaviour {

    // Line targets
    private Vector3 worldForward;
    private Vector3 localForward;

    // Line lenghts
    private readonly float worldForwardLenght = 20;
    private readonly float localForwardLenght = 30;

    public Transform[] enemies;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        // Draw a red line to each pointing to each enemy
        foreach (var enemy in enemies) {
            if (enemy != null) {
                Debug.DrawLine(this.transform.position, enemy.position, Color.red, 0, true);
            }
        }

        // Draw a green line always pointing forward in World Space
        worldForward = this.transform.position + (Vector3.forward * worldForwardLenght);
        Debug.DrawLine(this.transform.position, worldForward, Color.cyan, 0, true);

        // Draw a green line always pointing forward in Local Space
        localForward = this.transform.position + (this.transform.forward * localForwardLenght);
        Debug.DrawLine(this.transform.position, localForward, Color.green, 0, false);
    }
}
