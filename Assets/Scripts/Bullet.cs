using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage;
    public float speed;
    private Rigidbody2D _rb;
    
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.velocity = transform.right * speed;
        Destroy(gameObject, 3f);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.GetComponent<EnemyHealth>() != null)
        {
            EnemyHealth enemyHealth = col.gameObject.GetComponent<EnemyHealth>();
            enemyHealth.GetDamage(damage);
        }
        
        if (col.gameObject.GetComponent<BoomBarrelHealth>() != null)
        {
            BoomBarrelHealth barrelHealth = col.gameObject.GetComponent<BoomBarrelHealth>();
            barrelHealth.GetDamage(damage);
        }
        
        Destroy(gameObject);
    }
}
