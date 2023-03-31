using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    private float maxHealth = 100f;
    private float currentHealth;
    
    public Image fill;

    public float MaxHealth
    {
        get { return maxHealth; }
        set { maxHealth = value; }
    }

    public float CurrentHealth
    {
        get { return currentHealth; }
        set { currentHealth = value; }
    }
    
    void Start()
    {
        CurrentHealth = MaxHealth;
    }

    public void RestoreHealth(float healAmount)
    {
        CurrentHealth += healAmount;
        UpdateHealthBar();
        CurrentHealth = Mathf.Clamp(CurrentHealth, 0, MaxHealth);
        Debug.Log($"Player restored {healAmount} health. Current health: {CurrentHealth}");
    }
    
    public void TakeDamage(float damageAmount)
    {
        CurrentHealth -= damageAmount;
        UpdateHealthBar();
        AudioManager.instance.PlaySFX(4);

        if (CurrentHealth <= 0)
        {
            PlayerController.Instance.Died(); // Активация анимации смерти игрока.
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
