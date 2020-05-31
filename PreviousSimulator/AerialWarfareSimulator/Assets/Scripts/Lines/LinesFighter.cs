using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinesFighter : MonoBehaviour {

    // Fighter
    private Transform fighter;

    // Line targets
    private Vector3 targetForwardWorld;
    private Vector3 targetForwardLocal;

    // Line lenghts
    private readonly float forwardWorldLenght = 25;
    private readonly float forwardLocalLenght = 50;

    // Line Renderers
    private LineRenderer lineForwardLocal;
    private LineRenderer lineForwardWorld;

    // Render Flags
    private readonly bool renderOnGameView = false;
    private readonly bool renderOnSceneView = true;

    void Awake() {

        // Fighter
        fighter = GameObject.Find("Fighter").transform;

        // Line Renderers
        lineForwardLocal = this.transform.Find("ForwardLocal").GetComponent<LineRenderer>();
        lineForwardWorld = this.transform.Find("ForwardWorld").GetComponent<LineRenderer>();
    }

    void LateUpdate() {

        // Draw a green line always pointing forward in Local Space
        targetForwardLocal = fighter.position + (fighter.forward * forwardLocalLenght);

        if (renderOnGameView) {
            lineForwardLocal.SetPosition(0, fighter.position);
            lineForwardLocal.SetPosition(1, targetForwardLocal);
        }
        if (renderOnSceneView) {
            Debug.DrawLine(fighter.position, targetForwardLocal, Color.green, 0, true);
        }


        // Draw a cyan line always pointing forward in World Space
        targetForwardWorld = fighter.position + (Vector3.forward * forwardWorldLenght);

        if (renderOnGameView) {
            lineForwardWorld.SetPosition(0, fighter.position);
            lineForwardWorld.SetPosition(1, targetForwardWorld);
        }
        if (renderOnSceneView) {
            Debug.DrawLine(fighter.position, targetForwardWorld, Color.cyan, 0, true);
        }
    }
}