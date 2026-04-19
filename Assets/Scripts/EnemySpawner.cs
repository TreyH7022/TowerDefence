using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform spawnPoint;
    public Transform[] waypoints;

    public float spawnRate = 2f;
    public int enemiesPerWave = 5;

    private float countdown = 0f;
    private int enemiesSpawned = 0;

    void Update()
    {
        if (enemiesSpawned >= enemiesPerWave) return;

        if (countdown <= 0f)
        {
            SpawnEnemy();
            countdown = 1f / spawnRate;
        }

        countdown -= Time.deltaTime;
    }

void SpawnEnemy()
{
    GameObject enemy = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);

    EnemyMovement movement = enemy.GetComponent<EnemyMovement>();
    movement.Initialize(waypoints);

    enemiesSpawned++;
}
}