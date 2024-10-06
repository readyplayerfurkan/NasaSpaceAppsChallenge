using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Randomization : MonoBehaviour
{
    public GameObject objectPrefab; // Assign your object prefab in the inspector
    public int initialObjectCount = 10; // Initial number of objects to spawn
    public float spawnInterval = 2f; // Time between new spawns
    public float initialDelay = 3f; // Delay before the first batch of objects spawns
    public float activeTime = 20f; // Total time the spawner is active

    public GameObject gameOverText; // Assign your Game Over Text in the inspector
    public TextMeshProUGUI TimerText; // Assign your Timer Text in the inspector

    private Vector2 screenBounds;
    private float remainingTime; // Variable to keep track of remaining time

    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        remainingTime = activeTime; // Initialize remaining time
        StartCoroutine(SpawnInitialObjectsWithDelay());
        StartCoroutine(SpawnNewObjects());
        StartCoroutine(StopSpawningAfterTime());
    }

    void Update()
    {
        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime; // Decrease remaining time
            UpdateTimerText(); // Update the timer text
        }
    }

    void UpdateTimerText()
    {
        TimerText.text = Mathf.Ceil(remainingTime).ToString(); // Display the remaining time rounded up
    }

    IEnumerator SpawnInitialObjectsWithDelay()
    {
        yield return new WaitForSeconds(initialDelay); // Wait for the initial delay
        for (int i = 0; i < initialObjectCount; i++)
        {
            SpawnObject();
        }
    }

    IEnumerator SpawnNewObjects()
    {
        while (remainingTime > 0)
        {
            yield return new WaitForSeconds(spawnInterval);
            SpawnObject();
        }
    }

    IEnumerator StopSpawningAfterTime()
    {
        yield return new WaitForSeconds(activeTime); // Wait for the specified active time
        StopAllCoroutines(); // Stop all coroutines related to spawning
        ShowGameOver(); // Display the game over message
    }

    void SpawnObject()
    {
        Vector2 spawnPosition = new Vector2(Random.Range(-screenBounds.x, screenBounds.x), Random.Range(-screenBounds.y, screenBounds.y));
        Instantiate(objectPrefab, spawnPosition, Quaternion.identity);
    }

    void ShowGameOver()
    {
        gameOverText.SetActive(true); // Activate the Game Over text
    }

    public void Restart()
    {
        gameOverText.SetActive(false);
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        remainingTime = activeTime; // Initialize remaining time
        StartCoroutine(SpawnInitialObjectsWithDelay());
        StartCoroutine(SpawnNewObjects());
        StartCoroutine(StopSpawningAfterTime());
    }
}