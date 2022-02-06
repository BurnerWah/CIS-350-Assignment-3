/*
 * Jaden Pleasants
 * Assignment 3
 * Detects a collission (which should be with a ball) and destroys the object.
 * Additionally, adds a point to the player's score.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisionsX : MonoBehaviour {
    private StateManager SM;
    private void Start() {
        SM = StateManager.FindStateManager();
    }

    private void OnTriggerEnter(Collider other) {
        SM.AddPoint();
        Destroy(gameObject);
    }
}
