using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Enemy Prefabs")]
    public GameObject spawnedEnemy; // prefab enemy yang akan di-spawn

    [SerializeField] private int minimumKillsToIncreaseSpawnCount = 3;
    public int totalKill = 0;
    private int totalKillWave = 0;

    [SerializeField] private float spawnInterval = 3f;

    [Header("Spawned Enemies Counter")]
    public int spawnCount = 0;
    public int defaultSpawnCount = 1;
    public int spawnCountMultiplier = 1;
    public int multiplierIncreaseCount = 1;

    public CombatManager combatManager; // menghubungkan dengan CombatManager

    public bool isSpawning = false;

    private void Start()
    {
        // memulai spawn secara otomatis 
        StartCoroutine(SpawnEnemiesRoutine());
    }

    private IEnumerator SpawnEnemiesRoutine()
    {
        isSpawning = true;

        while (isSpawning)
        {
            // spawn musuh berdasarkan spawnCount
            for (int i = 0; i < spawnCount; i++)
            {
                SpawnEnemy();
                yield return new WaitForSeconds(spawnInterval);
            }

            yield return null;
        }
    }

    private void SpawnEnemy()
    {
        if (spawnedEnemy != null)
        {
            Instantiate(spawnedEnemy, transform.position, Quaternion.identity);
            spawnCount++;
        }
    }

    public void IncrementKillCount()
    {
        totalKill++;
        totalKillWave++;

        if (totalKillWave >= minimumKillsToIncreaseSpawnCount)
        {
            spawnCountMultiplier += multiplierIncreaseCount;
            totalKillWave = 0;
        }
    }
}
