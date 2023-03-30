using UnityEngine;

public class ExplosionDamage : MonoBehaviour
{
    public float damage;
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        PlayerHealth playerHealth = col.gameObject.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damage);
        }
    
        EnemyHealth enemyHealth = col.gameObject.GetComponent<EnemyHealth>();
        if (enemyHealth != null)
        {
            enemyHealth.TakeDamage(damage);
        }
    }
}
