using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] PlayerHealthController playerHealthController;

    public GameObject enemy;
    public GameObject exit;

    public float enemySpeed = 2;
    public float timeBetweenSpawns = 1;
    public float enemyDamage = 5;
    public List<GameObject> enemies = new List<GameObject>();

    private float timeUntilNextSpawn = 0;

    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        float dt = Time.deltaTime;

        timeUntilNextSpawn -= dt;

        while (timeUntilNextSpawn <= 0) {
            timeUntilNextSpawn += timeBetweenSpawns;

            SpawnEnemy();
        }

        UpdateEnemies(dt);
    }

    private void SpawnEnemy()
    {
        GameObject newEnemy = Instantiate(enemy);
        newEnemy.GetComponent<SpriteRenderer>().enabled = true;
        enemies.Add(newEnemy);
    }

    private void UpdateEnemies(float dt)
    {
        for (int i = enemies.Count - 1; i >= 0; i--)
        {
            GameObject enemy = enemies[i];

            enemy.transform.position += Vector3.right * dt * enemySpeed;

            if (enemy.transform.position.x >= exit.transform.position.x)
            {
                // Destroy enemy
                Destroy(enemy);
                enemies.RemoveAt(i);

                playerHealthController.TakeDamage(enemyDamage);
            }
        }
    }

    public void ResetEnemies()
    {
        for (int i = enemies.Count - 1; i >= 0; i--)
        {
            GameObject enemy = enemies[i];

            Destroy(enemy);
            enemies.RemoveAt(i);
        }

        timeUntilNextSpawn = 0;
    }

    public void DestroyEnemy(GameObject enemy, int i)
    {
        Destroy(enemy);
        enemies.RemoveAt(i);
    }
}
