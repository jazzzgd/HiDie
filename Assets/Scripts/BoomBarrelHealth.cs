using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class BoomBarrelHealth : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;
    public GameObject explosionEffect;
    
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void GetDamage(float damageAmount)
    {
        currentHealth -= damageAmount;
        
        if (currentHealth <= 0)
        {
            AudioManager.instance.PlaySFX(0);
            Explosion();
            Boom();
        }
    }

    public void Boom()
    {
        Destroy(gameObject);
    }

    public void Explosion()
    {
        GameObject obj = Instantiate(explosionEffect, transform.position, transform.rotation);
        Destroy(obj, 0.8f);
    }
}
