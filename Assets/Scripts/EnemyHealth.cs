using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;
    public Image fill;
    public int moneyEarn;
    public GameObject zombieBlood;
    
    private Animator animator;
    private Collider2D collider2D;
    
    void Start()
    {
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();
        collider2D = GetComponent<Collider2D>();
    }

    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;
        UpdateHealthBar();
        GameObject blood = Instantiate(zombieBlood, transform.position, transform.rotation);
        Destroy(blood, 2f);
        
        //если хп врага меньше или равно нулю, то вызывается функция Die.
        if (currentHealth <= 0)
        {
            Die();
            GameManager.Instance.money += moneyEarn;
            SaveManager.instance.activeSave.currentMoney = GameManager.Instance.money;
        }
    }

    private void UpdateHealthBar()
    {
        float hpBar = currentHealth / maxHealth;
        fill.fillAmount = hpBar;
        if (currentHealth <= 0)
        {
            fill.fillAmount = 0;
        }
    }
    
    private void Die()
    {
        animator.SetBool("isDead", true);
        collider2D.enabled = false;
        Destroy(gameObject, 10f);
        AudioManager.instance.PlaySFX(1);
    }
}
