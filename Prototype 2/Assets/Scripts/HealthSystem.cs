/*
 * Jaden Pleasants
 * Assignment 3
 * Manages the player's health
 */
//This script is based on https://www.youtube.com/watch?v=3uyolYVsiWc
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthSystem : MonoBehaviour {
    public int health;
    public int maxHealth;

    public List<Image> hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    public bool gameOver = false;

    public GameObject gameOverText;

    void Update() {
        //If health is somehow more than max health, set health to max health
        if (health > maxHealth) {
            health = maxHealth;
        }


        // I simplified the expressions here since I think they're overly complex
        for (int i = 0; i < hearts.Count; i++) {
            //Display full or empty heart sprite based on current health
            hearts[i].sprite = (i < health) ? fullHeart : emptyHeart;

            //Show the number of hearts equal to current max health
            hearts[i].enabled = (i < maxHealth);
        }

        if (health <= 0) {
            gameOver = true;
            gameOverText.SetActive(true);

            //Press R to restart if game is over
            if (Input.GetKeyDown(KeyCode.R)) {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }

    }

    public void TakeDamage() {
        health--;
    }

    public void AddMaxHealth() {
        maxHealth++;
    }


}
