using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    public EnemySpawner[] enemySpawners; 
    public float timer = 0;
    [SerializeField] private float waveInterval = 5f;
    public int waveNumber = 1;
    public int totalEnemies = 0;

    private void Start()
    {
        // mulai sistem wave otomatis
        StartCoroutine(WaveSystemRoutine());
    }

    private IEnumerator WaveSystemRoutine()
    {
        while (true)
        {
            // tunggu waktu antara wave
            yield return new WaitForSeconds(waveInterval);
            //setelah selesai nunggu, panggil StartWave buat mulai wave baru
            StartWave();
        }
    }

    private void StartWave()
    {
        waveNumber++;
        totalEnemies = 0;

        foreach (var spawner in enemySpawners)
        {
            // jumlah musuh yang dispawn sesuai wave
            spawner.spawnCount = spawner.defaultSpawnCount + (spawner.spawnCountMultiplier * waveNumber);
            spawner.isSpawning = true;
            totalEnemies += spawner.spawnCount; //total musuh dari spawnCount
        }

        Debug.Log($"Wave {waveNumber}. Total musuh: {totalEnemies}");
    }
}

