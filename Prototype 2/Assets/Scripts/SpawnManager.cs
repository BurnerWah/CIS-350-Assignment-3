/*
 * Jaden Pleasants
 * Assignment 3
 * Automatically spawns an animal every few seconds
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {
    // drag prefabs to spawn into this array in the inspector
    public GameObject[] prefabsToSpawn;
    private readonly float leftBound = -14;
    private readonly float rightBound = 14;
    private readonly float spawnPosZ = 20;
    public bool gameOver = false;
    public HealthSystem healthSystem;

    // Start is called before the first frame update
    void Start() {
        healthSystem = GameObject.FindGameObjectWithTag("HealthSystem").GetComponent<HealthSystem>();
        StartCoroutine(SpawnRandomPrefabWithCoroutine());
    }

    // Update is called once per frame
    void Update() {

    }

    IEnumerator SpawnRandomPrefabWithCoroutine() {
        // add 3 second delay before spawning anything
        yield return new WaitForSeconds(3f);

        while (!healthSystem.gameOver) {
            SpawnRandomPrefab();
            // wait another 1.5-3 seconds before spawning anything else
            float delay = Random.Range(1.5f, 3f);
            yield return new WaitForSeconds(delay);
        }
    }

    void SpawnRandomPrefab() {
        // Get random index to spawn
        int prefabIndex = Random.Range(0, prefabsToSpawn.Length);
        // generate spawn position
        var spawnPos = new Vector3(Random.Range(leftBound, rightBound), 0, spawnPosZ);
        // spawn prefab w/ random index at random position
        Instantiate(prefabsToSpawn[prefabIndex], spawnPos, prefabsToSpawn[prefabIndex].transform.rotation);
    }
}
