/*
 * Jaden Pleasants
 * Assignment 3
 * Delets prefabs the player shoots when they encounter an animal (also destroys the animal)
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// attach this to the food prefab
public class DetectCollisions : MonoBehaviour {
    private DisplayScore displayScoreScript;

    // Start is called before the first frame update
    void Start() {
        displayScoreScript = GameObject.FindGameObjectWithTag("DisplayScoreText").GetComponent<DisplayScore>();
    }

    // Update is called once per frame
    void Update() {

    }

    private void OnTriggerEnter(Collider other) {
        displayScoreScript.score++;
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
