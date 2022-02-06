/*
 * Jaden Pleasants
 * Assignment 3
 * This restarts the game when the R key is pressed.
 * It should be attached to the game over text.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartUtil : MonoBehaviour {
    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.R)) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
