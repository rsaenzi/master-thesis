using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinesEnemy : MonoBehaviour {

    // Fighter
    private Transform fighter;

    // Line Renderers
    private LineRenderer lineToFighter;

    // Render Flags
    private readonly bool renderOnGameView = false;
    private readonly bool renderOnSceneView = true;

    void Awake() {

        // Fighter
        fighter = GameObject.Find("Fighter").transform;

        // Line Renderers
        lineToFighter = this.GetComponent<LineRenderer>();
    }

    void LateUpdate() {

        // Draw a red line from the fighter to this enemy
        if (renderOnGameView) {
            lineToFighter.SetPosition(0, fighter.position);
            lineToFighter.SetPosition(1, this.transform.position);
        }
        if (renderOnSceneView) {
            Debug.DrawLine(fighter.position, this.transform.position, Color.red, 0, true);
        }
    }
}
