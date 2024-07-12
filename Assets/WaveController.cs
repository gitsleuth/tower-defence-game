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
    public TMPro.TMP_Text waveTimerText;

    private Wave[] waves = {
        new Wave(4),
        new Wave(6),
        new Wave(5)
    };
    private int waveNumber = 0;
    private int enemiesLeftToSpawn = 0;
    private float elapsed = 0;
    private bool spawnEnemies = false;
    private float nextWavePause = 10;
    private float nextWaveTimer;

    // Start is called before the first frame update
    private void Start()
    {
        nextWaveTimer = nextWavePause;
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
        } else if (enemyController.enemies.Count == 0 && spawnEnemies && waveNumber < waves.Length - 1)
        {
            nextWaveTimer -= Time.deltaTime;

            waveTimerText.text = "Starting new wave in " + Mathf.Round(nextWaveTimer) + "s";

            waveTimerText.enabled = true;

            if (nextWaveTimer <= 0)
            {
                nextWaveTimer = nextWavePause;

                waveNumber += 1;

                StartWave(waves[waveNumber]);

                waveTimerText.enabled = false;
            }
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
