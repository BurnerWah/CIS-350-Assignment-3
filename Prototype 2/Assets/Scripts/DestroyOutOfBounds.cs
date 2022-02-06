/*
 * Jaden Pleasants
 * Assignment 3
 * Destroys prefabs when they're out of bounds
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// attach this to food & animal prefabs
public class DestroyOutOfBounds : MonoBehaviour {
    private readonly float topBound = 20;
    private readonly float bottomBound = -10;
    private HealthSystem healthSystem;
    // Start is called before the first frame update
    void Start() {
        healthSystem = GameObject.FindGameObjectWithTag("HealthSystem").GetComponent<HealthSystem>();
    }

    // Update is called once per frame
    void Update() {
        // Food going OOB isn't notable
        if (transform.position.z > topBound) {
            Destroy(gameObject);
        }
        // animals going OOB means that the player loses health
        if (transform.position.z < bottomBound) {
            healthSystem.TakeDamage();
            Destroy(gameObject);
        }
    }
}
