using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private float _nextShotTime;
    public float shotsPerSecond;
    public Bullet bullet;
    public Transform firePoint;
    public float damage;

    public void Shoot()
    {
        if (_nextShotTime <= Time.time)
        {
            Bullet bulletShot = Instantiate(bullet, firePoint.position, firePoint.rotation);
            bulletShot.damage = damage;
            _nextShotTime = Time.time + (1 / shotsPerSecond);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
