/*
 * Jaden Pleasants
 * Assignment 3
 * Shoots a prefab from the player's position
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// attach this script to the player
public class ShootPrefab : MonoBehaviour {
    // set this in inspector
    public GameObject prefabToShoot;
    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            Instantiate(prefabToShoot, transform.position, prefabToShoot.transform.rotation);
        }
    }
}
