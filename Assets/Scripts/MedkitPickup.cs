using UnityEngine;

public class MedkitPickup : MonoBehaviour
{
    public float healAmount;

    void OnTriggerEnter2D(Collider2D other)
    {
        // Проверка коллайдера
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerHealth playerHealth = other.gameObject.GetComponent<PlayerHealth>();
            
            // Восстановление жизней игрока на количество
            if (playerHealth != null)
            {
                playerHealth.RestoreHealth(healAmount);
                AudioManager.instance.PlaySFX(5);
                Destroy(gameObject);
            }
        }
    }
}
