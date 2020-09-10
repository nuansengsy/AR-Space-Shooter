using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlanetHeath : MonoBehaviour
{
    public int maxHealth = 5;
    public int currentHealth;

    public Text healthText;
    public HealthBar healthBar;
    void Start()
    {
        DelegatesHandler.MeteorHitted += TakeDamage;
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage();
        }
    }


    void TakeDamage()
    {
        if(currentHealth > 0)
        {
            currentHealth--;
            healthBar.SetHealth(currentHealth);

            healthText.text = currentHealth.ToString();
            if (currentHealth <= 0)
            {
                DelegatesHandler.SharedInstance.FinishGame();
            }
        }
    }

}
