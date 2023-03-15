using UnityEngine;

public class Weapon : MonoBehaviour
{
    private float _nextShotTime;
    public Bullet bullet;
    public Transform[] firePoints;
    public float shotsPerSecond;
    public float damage;
    public int ammo;
    public Sprite weaponIcon;

    public void Shoot()
    {
        if (_nextShotTime <= Time.time && ammo > 0)
        {
            foreach (Transform firePoint in firePoints)
            {
                Bullet bulletShot = Instantiate(bullet, firePoint.position, firePoint.rotation);
                bulletShot.damage = damage;
            }
            
            _nextShotTime = Time.time + (1 / shotsPerSecond);
            ammo--;
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
