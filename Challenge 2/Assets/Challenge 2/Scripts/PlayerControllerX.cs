using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour {
    public GameObject dogPrefab;

    private bool canSpawnDog = true;
    void Start() {
        canSpawnDog = true;
    }

    // Update is called once per frame
    void Update() {
        // On spacebar press, send dog
        if (canSpawnDog && Input.GetKeyDown(KeyCode.Space)) {
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
            canSpawnDog = false;
            StartCoroutine(UnlockSpawning());
        }
    }

    private IEnumerator UnlockSpawning() {
        yield return new WaitForSeconds(2.5f);
        canSpawnDog = true;
    }
}
