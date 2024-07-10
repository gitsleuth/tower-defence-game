using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Wave
{
    public Wave(int enemies)
    {
        Enemies = enemies;
    }

    public int Enemies { get; }
}

public class WaveController : MonoBehaviour
{
    [SerializeField] EnemyController enemyController;

    public TMPro.TMP_Text waveText;

    private Wave[] waves = {
        new Wave(4),
        new Wave(6),
        // new Wave(5)
    };
    private int waveNumber = 0;
    private int enemiesLeftToSpawn = 0;
    private float elapsed = 0;
    private bool spawnEnemies = false;

    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        if (enemiesLeftToSpawn > 0)
        {
            elapsed -= Time.deltaTime;
            if (elapsed <= 0)
            {
                enemiesLeftToSpawn -= 1;
                if (enemiesLeftToSpawn > 0)
                {
                    elapsed += 4;
                }
                enemyController.SpawnEnemy();
            }
        }

        if (enemyController.enemies.Count == 0 && spawnEnemies && waveNumber < waves.Length - 1)
        {
            waveNumber += 1;

            StartWave(waves[waveNumber]);
        }
    }

    private void StartWave(Wave wave)
    {
        waveText.text = "Wave: " + (waveNumber + 1);

        enemiesLeftToSpawn = wave.Enemies;
    }

    public void StartSpawningWaves()
    {
        Wave wave = waves[waveNumber];

        StartWave(wave);

        spawnEnemies = true;
    }
}
