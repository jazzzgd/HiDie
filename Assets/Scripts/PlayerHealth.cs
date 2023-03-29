using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth;
    public Image fill;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void RestoreHealth(float healAmount)
    {
        currentHealth += healAmount; // Increase the player's health by the specified amount
        UpdateHealthBar();
        // Clamp the player's health to the maximum
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        Debug.Log("Player restored " + healAmount + " health. Current health: " + currentHealth);
    }
    
    public void GetDamage(float damageAmount)
    {
        currentHealth -= damageAmount;
        UpdateHealthBar();
        AudioManager.instance.PlaySFX(4);
        //Если хп врага меньше или равно нулю, то вызывается функция Died.
        if (currentHealth <= 0)
        {
            PlayerController.Instance.Died();//Активация анимации смерти игрока.
        }
    }

    public void UpdateHealthBar()
    {
        float hpBar = currentHealth / maxHealth;
        fill.fillAmount = hpBar;
        if (currentHealth <= 0)
        {
            fill.fillAmount = 0;
        }
    }
}
