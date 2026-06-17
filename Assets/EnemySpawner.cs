using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform[] spawnPoints;

    public WaveManager waveManager;

    public void SpawnEnemies(int count)
    {
        if (spawnPoints == null || spawnPoints.Length == 0)
        {
            Debug.LogError("SpawnPointsが設定されていません");
            return;
        }

        for (int i = 0; i < count; i++)
        {
            Transform sp = spawnPoints[Random.Range(0, spawnPoints.Length)];

            GameObject enemy = Instantiate(enemyPrefab, sp.position, Quaternion.identity);

            // ★ ここが重要（生成時に登録）
            EnemyHealth hp = enemy.GetComponent<EnemyHealth>();

            hp.onDeath += OnEnemyKilled;
        }
    }

    public void OnEnemyKilled()
    {
        waveManager.OnEnemyKilled();
    }
}