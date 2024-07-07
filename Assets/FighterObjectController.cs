using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterObjectController : MonoBehaviour
{
    [SerializeField] EnemyController enemyController;
    [SerializeField] InputController inputController;
    [SerializeField] ProjectileController projectileController;

    public bool fireRadiusEnabled = false;
    public GameObject fighterObjectTouchedBefore = null;
    public List<GameObject> fighters = new List<GameObject>();

    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        foreach (GameObject fighter in fighters)
        {
            foreach (GameObject enemy in enemyController.enemies)
            {
                if ((fighter.transform.position - enemy.transform.position).magnitude <= inputController.fireRadius.transform.localScale.x)
                {
                    Vector3 direction = enemy.transform.position - fighter.transform.position;
                    float dist = direction.magnitude;
                    direction.Normalize();
                    float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

                    fighter.transform.rotation = Quaternion.Euler(0f, 0f, angle);

                    projectileController.SpawnProjectile(fighter.transform.position + direction * 1, Quaternion.Euler(0f, 0f, angle + 90), fighter.transform.forward);
                }
            }
        }
    }

    public void RegisterFighterObject(GameObject fighter)
    {
        fighters.Add(fighter);
    }

    public void DestroyAllFighters()
    {
        for (int i = fighters.Count - 1; i >= 0; i--)
        {
            GameObject fighter = fighters[i];

            Destroy(fighter);
            fighters.RemoveAt(i);
        }
    }
}
