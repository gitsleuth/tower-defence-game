using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] PlayerHealthController playerHealthController;
    [SerializeField] EnemyController enemyController;
    [SerializeField] FighterObjectController fighterObjectController;
    [SerializeField] WaveController waveController;

    // Start is called before the first frame update
    private void Start()
    {
        waveController.StartSpawningWaves();
    }

    // Update is called once per frame
    private void Update()
    {
        
    }

    public void ResetGame()
    {
        playerHealthController.ResetPlayerHealth();
        enemyController.ResetEnemies();
        fighterObjectController.DestroyAllFighters();
    }
}
