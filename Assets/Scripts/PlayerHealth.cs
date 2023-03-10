using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth;
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

    public void GetDamage(float damageAmount)
    {
        currentHealth -= damageAmount;
        UpdateHealthBar();  
        
        //если хп врага меньше или равно нулю, то вызывается функция Died.
        if (currentHealth <= 0)
        {
            //Died();
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
    
    public void Died()
    {
        Destroy(gameObject);
    }
}
