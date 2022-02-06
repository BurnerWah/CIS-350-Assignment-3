/*
 * Jaden Pleasants
 * Assignment 3
 * Displays the score in the UI
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayScore : MonoBehaviour {
    public Text textbox;
    public int score = 0;
    
    // Start is called before the first frame update
    void Start() {
        // Set up the reference to the text component on this gameobjeect
        textbox = GetComponent<Text>();
        textbox.text = "Sscore: 0";
    }

    // Update is called once per frame
    void Update() {
        textbox.text = $"Score: {score}";
    }
}
