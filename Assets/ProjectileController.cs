using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    [SerializeField] EnemyController enemyController;

    public GameObject projectile;
    public float bulletSpeed = 5;
    public float projectileDamage = 10;

    private List<GameObject> projectiles = new List<GameObject>();

    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        for (int i = projectiles.Count - 1; i >= 0; i--)
        {
            GameObject projectile = projectiles[i];

            projectile.transform.position += -projectile.transform.up * bulletSpeed * Time.deltaTime;

            for (int j = enemyController.enemies.Count - 1; j >= 0; j--)
            {
                GameObject enemy = enemyController.enemies[j];

                if (projectile.GetComponent<CircleCollider2D>().bounds.Intersects(enemy.GetComponent<CircleCollider2D>().bounds))
                {
                    Destroy(projectile);
                    projectiles.RemoveAt(i);

                    enemyController.DealDamageToEnemy(enemy, j, projectileDamage);
                }
            }
        }
    }

    public void SpawnProjectile(Vector3 origin, Quaternion rotation)
    {
        GameObject newProjectile = Instantiate(projectile, origin, rotation);
        newProjectile.GetComponent<SpriteRenderer>().enabled = true;
        newProjectile.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = true;
        projectiles.Add(newProjectile);
    }
}
