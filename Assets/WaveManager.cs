using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public EnemySpawner spawner;

    public int currentWave = 0;
    public int enemiesAlive = 0;

    public int baseCount = 3;

    void Start()
    {
        StartNextWave();
    }

    public void StartNextWave()
    {
        currentWave++;

        int spawnCount = baseCount + (currentWave - 1) * 2;

        enemiesAlive = spawnCount;

        Debug.Log("Wave " + currentWave + " Start: " + enemiesAlive);

        spawner.SpawnEnemies(spawnCount);
    }

    public void OnEnemyKilled()
    {
        enemiesAlive--;

        Debug.Log("Enemy killed. Remaining: " + enemiesAlive);

        if (enemiesAlive <= 0)
        {
            Debug.Log("Wave Cleared");

            Invoke("StartNextWave", 2f);
        }
    }
}