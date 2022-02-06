/*
 * Jaden Pleasants
 * Assignment 3
 * Do... do I need to say it for this one?
 * It moves something forward.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// attach this script to the animals & food
public class MoveForward : MonoBehaviour {
    public float speed = 40;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
}
