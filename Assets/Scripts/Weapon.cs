using System;
using Unity.VisualScripting;
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
    public Animator fireAnim;

    [Header("Audio")] 
    private AudioSource audioSource;
    public AudioClip shootSound;
    [Range(0f, 1f)] public float audioVolume = 1f;
    [Range(0f, 1f)] public float audioPitch = 1f;
    
    private void Start()
    {
        fireAnim = GetComponentInChildren<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        audioSource.volume = audioVolume;
        audioSource.pitch = audioPitch;
    }

    public void Shoot()
    {
        fireAnim.SetTrigger("Fire");
        
        if (_nextShotTime <= Time.time && ammo > 0)
        {
            foreach (Transform firePoint in firePoints)
            {
                Bullet bulletShot = Instantiate(bullet, firePoint.position, firePoint.rotation);
                bulletShot.damage = damage;
            }
            
            _nextShotTime = Time.time + (1 / shotsPerSecond);
            ammo--;
            audioSource.PlayOneShot(shootSound);
        }
    }
}
