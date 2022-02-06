/*
 * Jaden Pleasants
 * Assignment 3
 * Unified manager for game states
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StateManager : MonoBehaviour {
    public Text scoreTextBox;
    public Text gameOverTextBox;

    // All score & health management should be abstracted away from directly manipulating values
    private int score;
    private int health;
    private readonly int maxScore = 5;

    // This is public so other things can READ it, but it should not be written to by other scripts.
    // It's also kept static to avoid needing to find the state manager every time.
    public static bool hasGameEnded;

    // Static function for other things to use to find this component
    public static StateManager FindStateManager() {
        return GameObject.FindGameObjectWithTag("StateManager").GetComponent<StateManager>();
    }

    // Start is called before the first frame update
    void Start() {
        score = 0;
        health = 1;
        hasGameEnded = false;
        scoreTextBox.gameObject.SetActive(true);
        gameOverTextBox.gameObject.SetActive(false);
        UpdateScoreBox();
    }

    /*
     * This and TakeDamage() handle state management in a somewhat nonstandard way (ex. updating the score & health in a condition).
     * I did this to reduce the linecount mostly, and also because I just kinda prefer this soution.
     * Additionally the further abstracted design allows the removal of the Update function entirely.
     */
    public void AddPoint() {
        if (!hasGameEnded) {
            if (++score >= maxScore) {
                GameOver(true);
            }
            else {
                UpdateScoreBox();
            }
        }
    }

    public void TakeDamage() {
        if (!hasGameEnded) {
            if (--health <= 0) {
                GameOver(false);
            }
            else {
                UpdateScoreBox();
            }
        }
    }

    /*
     * This marks the game as having ended (for other things to use ex. for optimization),
     * hides the score box, sets the text for the end screen, and enables it.
     * The end screen itself actually handles restarting the game.
     */
    private void GameOver(bool didPlayerWin) {
        hasGameEnded = true;
        scoreTextBox.gameObject.SetActive(false);
        gameOverTextBox.text = $"You {(didPlayerWin ? "win" : "lose")}!\nPress R to restart.";
        gameOverTextBox.gameObject.SetActive(true);
    }

    /*
     * This abstraction would be IMO better as an inline function, but I don't think C# has those.
     * Either way it does ensure that code should never have to directly modify the text box.
     * This also helps us avoid reliance upon the Update function.
     */
    private void UpdateScoreBox() {
        scoreTextBox.text = $"Score: {score}\nHealth: {health}";
    }
}
