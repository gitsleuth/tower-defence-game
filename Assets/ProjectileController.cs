using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
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
            data.Key.transform.position += -data.Key.transform.up * bulletSpeed * Time.deltaTime;
        }
    }

    public void SpawnProjectile(Vector3 origin, Quaternion rotation, Vector3 direction)
    {
        projectiles.Add(Instantiate(projectile, origin, rotation), direction);
    }
}
