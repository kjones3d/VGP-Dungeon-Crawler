using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages enemy wave spawning using arrays and lists
/// Week 2 - Day 2: Arrays and Lists
/// </summary>
public class WaveManager : MonoBehaviour
{
    public static WaveManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    [Header("Enemy Prefabs")]
    public GameObject ghostPrefab;
    public GameObject gruntPrefab;
    public GameObject demonPrefab;

    [Header("Spawn Settings")]
    // TODO: Declare Vector3[] spawnPoints array for 4 positions

    public Vector3[] spawnPoints;

    // Wave Patterns - Array of arrays (2D array)
    // Format: {goblins, ogres, bosses}
    // TODO: Declare int[][] wavePatterns
    // Wave 1: 3 goblins, 0 ogres, 0 bosses
    // Wave 2: 5 goblins, 2 ogres, 0 bosses
    // Wave 3: 2 goblins, 3 ogres, 1 boss

    private int[][] wavePatterns;

    // Active Enemies - Dynamic list
    // TODO: Declare List<GameObject> activeEnemies

    private List<GameObject> activeEnemies;

    private int currentWave = 0;

    void Start()
    {
        // TODO: Initialize spawnPoints array with 4 Vector3 positions
        spawnPoints = new Vector3[4];
        spawnPoints[0] = new Vector3(-5, -2, 0);
        spawnPoints[1] = new Vector3(5, -2, 0);
        spawnPoints[2] = new Vector3(-5, 2, 0);
        spawnPoints[3] = new Vector3(5, 2, 0);

        // TODO: Initialize wavePatterns (already shown above)
        wavePatterns = new int[3][];
        wavePatterns[0] = new int[] { 3, 0, 0 }; //Wave 1: 3 goblins
        wavePatterns[1] = new int[] { 5, 2, 0 }; //Wave 2: 5 goblins, 2 ogres
        wavePatterns[2] = new int[] { 2, 3, 1 }; //Wave 3: 2 gobs, 3 ogres, 1 boss

        // TODO: Initialize activeEnemies list
        activeEnemies = new List<GameObject>();

        // Start first wave
        SpawnWave(currentWave);
    }

    /// <summary>
    /// Spawns enemies based on the wave pattern
    /// </summary>
    /// <param name="waveIndex">Which wave to spawn</param>
    void SpawnWave(int waveIndex)
    {
        Debug.Log("Spawning Wave " + (waveIndex + 1));

        // TODO: Get the current wave pattern from the array
        int[] pattern = wavePatterns[waveIndex];

        // TODO: Spawn goblins (pattern[0])
        for (int i = 0; i < pattern[0]; i++)
        {
            SpawnEnemy(ghostPrefab);
        }

        // TODO: Spawn ogres (pattern[1])
        for (int i = 0; i < pattern[1]; i++)
        {
            SpawnEnemy(gruntPrefab);
        }
        // TODO: Spawn bosses (pattern[2])
        for (int i = 0; i < pattern[2]; i++)
        {
            SpawnEnemy(demonPrefab);
        }

        Debug.Log("Active enemies: " + activeEnemies.Count);
    }
    void StartSpawn()
    {
        SpawnWave(currentWave);
    }
    /// <summary>
    /// Spawns a single enemy at a spawn point
    /// </summary>
    /// <param name="enemyPrefab">The enemy prefab to spawn</param>
    void SpawnEnemy(GameObject enemyPrefab)
    {
        // TODO: Pick a random spawn point from the array
        int randomIndex = Random.Range(0, spawnPoints.Length);
        Vector3 spawnPosition = spawnPoints[randomIndex];

        // TODO: Spawn the enemy at that position
        GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

        // TODO: Add enemy to activeEnemies list
        activeEnemies.Add(enemy);
    }

    /// <summary>
    /// Removes an enemy from the active list (called when defeated)
    /// </summary>
    /// <param name="enemy">The enemy to remove</param>
    public void RemoveEnemy(GameObject enemy)
    {
        // TODO: Remove from list
        activeEnemies.Remove(enemy);

        Debug.Log("Enemy removed. Remaining: " + activeEnemies.Count);

        // TODO: Check if wave is complete (no enemies left)
        if (activeEnemies.Count == 0)
        {
            NextWave();
        }
    }

    /// <summary>
    /// Advances to the next wave
    /// </summary>
    void NextWave()
    {
        currentWave++;

        // Check if there are more waves
        if (currentWave < wavePatterns.Length)
        {
            Debug.Log("Wave " + currentWave + " complete! Starting next wave...");
            Invoke("StartSpawn", 2f); // Wait 2 seconds before next wave
        }
        else
        {
            Debug.Log("All waves complete! You win!");
        }
    }

    // Display info for debugging
    void OnGUI()
    {
        GUI.Label(new Rect(10, 40, 300, 20), "Wave: " + (currentWave + 1) + " / " + wavePatterns.Length);
        GUI.Label(new Rect(10, 60, 300, 20), "Active Enemies: " + activeEnemies.Count);
    }
}
