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
    public float defaultEnemyHealth = 20;
    public GameObject enemyHealthTextObject;
    public Transform canvasTrans;

    private float timeUntilNextSpawn = 0;
    private Dictionary<GameObject, float> enemyHealth = new Dictionary<GameObject, float>();
    private Dictionary<GameObject, TMPro.TextMeshProUGUI> enemyHealthText = new Dictionary<GameObject, TMPro.TextMeshProUGUI>();

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

        UpdateHealthTextPositions();
    }

    private void SpawnEnemy()
    {
        GameObject newEnemy = Instantiate(enemy);
        newEnemy.GetComponent<SpriteRenderer>().enabled = true;
        Transform healthBarHolderTrans = newEnemy.transform.GetChild(0);
        healthBarHolderTrans.GetComponent<SpriteRenderer>().enabled = true;
        Transform healthBarTrans = healthBarHolderTrans.GetChild(0);
        healthBarTrans.GetComponent<SpriteRenderer>().enabled = true;
        enemyHealth.Add(newEnemy, defaultEnemyHealth);
        GameObject healthText = Instantiate(enemyHealthTextObject, healthBarTrans.position + Vector3.up * 1, enemyHealthTextObject.transform.rotation);
        healthText.GetComponent<TMPro.TMP_Text>().enabled = true;
        healthText.transform.SetParent(canvasTrans);
        enemyHealthText.Add(newEnemy, healthText.GetComponent<TMPro.TextMeshProUGUI>());
        UpdateHealthUI(newEnemy);
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

        Destroy(enemyHealthText[enemy]);
        enemyHealthText.Remove(enemy);
    }

    public void DealDamageToEnemy(GameObject enemy, int i, float damage)
    {
        enemyHealth[enemy] -= damage;

        UpdateHealthUI(enemy);

        if (enemyHealth[enemy] <= 0)
        {
            enemyHealth.Remove(enemy);

            DestroyEnemy(enemy, i);
        }
    }

    public void UpdateHealthUI(GameObject enemy)
    {
        Transform healthBarTrans = enemy.transform.GetChild(0).GetChild(0);
        float thisEnemyHealth = enemyHealth[enemy];
        float healthPercentage = thisEnemyHealth / defaultEnemyHealth;
        healthBarTrans.localScale = new Vector3(healthPercentage, 1, 1);
        healthBarTrans.localPosition = Vector3.left * (1 - healthPercentage) / 2;
        enemyHealthText[enemy].text = thisEnemyHealth + "/" + defaultEnemyHealth;
    }

    public void UpdateHealthTextPositions()
    {
        foreach (KeyValuePair<GameObject, TMPro.TextMeshProUGUI> data in enemyHealthText)
        {
            Transform healthBarHolderTrans = data.Key.transform.GetChild(0);
            data.Value.transform.position = Camera.main.WorldToScreenPoint(healthBarHolderTrans.position + Vector3.up * 0.2f);
        }
    }
}
