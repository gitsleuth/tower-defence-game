using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    public TMPro.TextMeshProUGUI playerHealthTextGUI;

    public float playerHealth = 100;

    // Start is called before the first frame update
    private void Start()
    {
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

    // We'll use this later
    public void OnPlayerDead()
    {
        print("Player died");
    }

    private void DisplayPlayerHealth()
    {
        playerHealthTextGUI.text = "Player Health: " + playerHealth.ToString();
    }
}
