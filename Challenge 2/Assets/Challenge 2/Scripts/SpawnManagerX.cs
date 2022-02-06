/*
 * Jaden Pleasants
 * Assignment 3
 * Automatically spawns random ball prefabs until the game ends.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerX : MonoBehaviour {
    public GameObject[] ballPrefabs;

    private readonly float spawnLimitXLeft = -22;
    private readonly float spawnLimitXRight = 7;
    private readonly float spawnPosY = 30;

    private readonly float startDelay = 1.0f;

    // Start is called before the first frame update
    void Start() {
        StartCoroutine(CoSpawner());
    }

    IEnumerator CoSpawner() {
        yield return new WaitForSeconds(startDelay);
        while (!StateManager.hasGameEnded) {
            SpawnRandomBall();
            yield return new WaitForSeconds(Random.Range(3.0f, 5.0f));
        }
    }

    // Spawn random ball at random x position at top of play area
    void SpawnRandomBall() {
        // Generate random ball index and random spawn position
        Vector3 spawnPos = new Vector3(Random.Range(spawnLimitXLeft, spawnLimitXRight), spawnPosY, 0);

        var index = Random.Range(0, ballPrefabs.Length);

        // instantiate ball at random spawn location
        Instantiate(ballPrefabs[index], spawnPos, ballPrefabs[index].transform.rotation);
    }

}
