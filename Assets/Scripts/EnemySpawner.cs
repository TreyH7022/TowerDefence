using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform spawnPoint;
    public Transform[] waypoints;
    public int waveNumber = 1;
    public float timeBetweenWaves = 5f;

    private float countdown = 2f;
    private bool isSpawning = false;

    void Update()
    {
        if (countdown <= 0f && !isSpawning)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }

        countdown -= Time.deltaTime;
    }

    IEnumerator SpawnWave()
    {
        isSpawning = true; 

        Debug.Log("Starting Wave " + waveNumber);

        int enemiesThisWave = 5 + (waveNumber * 2);

        for (int i = 0; i < enemiesThisWave; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }

        waveNumber++;

        isSpawning = false; 
    }

    void SpawnEnemy()
    {
        GameObject enemy = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);

        EnemyMovement movement = enemy.GetComponent<EnemyMovement>();
        movement.Initialize(waypoints);

        movement.speed += waveNumber * 0.5f;
    }
}