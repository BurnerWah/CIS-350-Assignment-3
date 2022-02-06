/*
 * Jaden Pleasants
 * Assignment 3
 * Handles player inputs
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    // does this need to be public? imo it doesn't
    private float horizontalInput;
    public float speed = 10.0f;
    private readonly float xRange = 14;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        // get horizontal input
        horizontalInput = Input.GetAxis("Horizontal");

        // transform horizontally w/ input
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);

        // keep player in-bounds
        // could maybe be down in a singullar check with absolute values but it's not important
        if (transform.position.x < -xRange) {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xRange) {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
    }
}
