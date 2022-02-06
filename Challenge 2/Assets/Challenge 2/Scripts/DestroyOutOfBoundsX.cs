/*
 * Jaden Pleasants
 * Assignment 3
 * Destroys objects when they go out of bounds.
 * Also makes the player take damage if it goes below the screen (which presumably will only occur with ball prefabs).
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBoundsX : MonoBehaviour {
    private float leftLimit = -30;
    private float bottomLimit = -5;
    private StateManager SM;

    private void Start() {
        SM = StateManager.FindStateManager();
    }

    // Update is called once per frame
    void Update() {
        // Destroy dogs if x position less than left limit
        if (transform.position.x < leftLimit) {
            Destroy(gameObject);
        }
        // Destroy balls if y position is less than bottomLimit
        else if (transform.position.y < bottomLimit) {
            SM.TakeDamage();
            Destroy(gameObject);
        }
    }
}
