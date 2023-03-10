using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public float damage;
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.GetComponent<PlayerHealth>() != null)
        {
            PlayerHealth _playerHealth = col.gameObject.GetComponent<PlayerHealth>();
            _playerHealth.GetDamage(damage);
        }
    }
}
