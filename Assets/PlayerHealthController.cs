using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    [SerializeField] GameController gameController;

    public TMPro.TextMeshProUGUI playerHealthTextGUI;

    public float playerHealth;
    public float startingPlayerHealth = 100;

    // Start is called before the first frame update
    private void Start()
    {
        ResetPlayerHealth();

        DisplayPlayerHealth();
    }

    // Update is called once per frame
    private void Update()
    {
        
    }

    public void TakeDamage(float damage)
    {
        playerHealth -= damage;

        if (playerHealth <= 0)
        {
            OnPlayerDead();
        }

        DisplayPlayerHealth();
    }

    public void OnPlayerDead()
    {
        gameController.ResetGame();
    }

    private void DisplayPlayerHealth()
    {
        playerHealthTextGUI.text = "Player Health: " + playerHealth.ToString();
    }

    public void ResetPlayerHealth()
    {
        playerHealth = startingPlayerHealth;
    }
}
