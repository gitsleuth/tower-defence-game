using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    [SerializeField] EnemyController enemyController;

    public GameObject projectile;
    public float bulletSpeed = 5;

    private Dictionary<GameObject, Vector3> projectiles = new Dictionary<GameObject, Vector3>();

    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        foreach (KeyValuePair<GameObject, Vector3> data in projectiles)
        {
            GameObject projectile = data.Key;

            projectile.transform.position += -projectile.transform.up * bulletSpeed * Time.deltaTime;

            for (int i = enemyController.enemies.Count - 1; i >= 0; i--)
            {
                GameObject enemy = enemyController.enemies[i];

                if (projectile.GetComponent<CircleCollider2D>().bounds.Intersects(enemy.GetComponent<CircleCollider2D>().bounds))
                {
                    enemyController.DestroyEnemy(enemy, i);
                }
            }
        }
    }

    public void SpawnProjectile(Vector3 origin, Quaternion rotation, Vector3 direction)
    {
        GameObject newProjectile = Instantiate(projectile, origin, rotation);
        newProjectile.GetComponent<SpriteRenderer>().enabled = true;
        newProjectile.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = true;
        projectiles.Add(newProjectile, direction);
    }
}
