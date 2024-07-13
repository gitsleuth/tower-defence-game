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
    public UnityEngine.UI.Button startNewWaveButton;

    private Wave[] waves = {
        new Wave(4),
        new Wave(8),
        new Wave(4),
    };
    private int waveNumber = 0;
    private int enemiesLeftToSpawn = 0;
    private Dictionary<int, float> elapsed = new Dictionary<int, float>();
    private bool spawnEnemies = false;
    private float nextWavePause = 5;
    private float nextWaveTimer;
    private float timeUntilCanStartNewWave;

    // Start is called before the first frame update
    private void Start()
    {
        nextWaveTimer = nextWavePause;

        startNewWaveButton.onClick.AddListener(() => NextWave());
    }

    // Update is called once per frame
    private void Update()
    {
        if (enemiesLeftToSpawn > 0)
        {
            //int elapsedIndex = GetElapsedIndex();

            //float dt = Time.deltaTime;
            //timeUntilCanStartNewWave -= dt;
            //elapsed -= dt;
            //if (elapsed <= 0)
            //{
            //    enemiesLeftToSpawn -= 1;
            //    if (enemiesLeftToSpawn > 0)
            //    {
            //        elapsed += 1;
            //    }
            //    enemyController.SpawnEnemy();
            //}

            foreach (KeyValuePair<int, float> data in elapsed)
            {
                elapsed[data.Key] -= Time.deltaTime;
            }

            if (timeUntilCanStartNewWave <= 0 && waveNumber < waves.Length - 1)
            {
                startNewWaveButton.GetComponent<UnityEngine.UI.Image>().enabled = true;
                startNewWaveButton.transform.GetChild(0).GetComponent<TMPro.TMP_Text>().enabled = true;
            }
        } else if (enemyController.enemies.Count == 0 && spawnEnemies && waveNumber < waves.Length - 1)
        {
            nextWaveTimer -= Time.deltaTime;

            waveTimerText.text = "Starting new wave in " + Mathf.Round(nextWaveTimer) + "s";

            waveTimerText.enabled = true;

            if (nextWaveTimer <= 0)
            {
                nextWaveTimer = nextWavePause;

                NextWave();

                waveTimerText.enabled = false;
            }
        }
    }

    private void NextWave()
    {
        waveNumber += 1;

        StartWave(waves[waveNumber]);
    }

    private void StartWave(Wave wave)
    {
        waveText.text = "Wave: " + (waveNumber + 1);

        enemiesLeftToSpawn = wave.Enemies;

        timeUntilCanStartNewWave = 20;

        //elapsed.Add(0);
    }

    public void StartSpawningWaves()
    {
        Wave wave = waves[waveNumber];

        StartWave(wave);

        spawnEnemies = true;
    }

    //public int GetElapsedIndex()
    //{

    //}
}
