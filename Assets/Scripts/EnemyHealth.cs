using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;
    public Image fill;
    private Animator _animator;
    public int moneyEarn;
    public GameObject zombieBlood;
    
    void Start()
    {
        currentHealth = maxHealth;
        _animator = GetComponent<Animator>();
    }

    public void GetDamage(float damageAmount)
    {
        currentHealth -= damageAmount;
        UpdateHealthBar();
        GameObject obj = Instantiate(zombieBlood, transform.position, transform.rotation);
        Destroy(obj, 2f);
        //если хп врага меньше или равно нулю, то вызывается функция Died.
        if (currentHealth <= 0)
        {
            Died();
            GameManager.Instance.money += moneyEarn;
            SaveManager.instance.activeSave.currentMoney = GameManager.Instance.money;
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
        _animator.SetBool("isDead", true);
        GetComponent<Collider2D>().enabled = false;
        Destroy(gameObject, 10);
        AudioManager.instance.PlaySFX(1);
    }
}
