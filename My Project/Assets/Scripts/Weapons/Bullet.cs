using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("Bullet Stats")]
    public float bulletSpeed = 20;
    public int damage = 10;

    private Rigidbody2D rb;
    private Weapon weapon;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        weapon = FindObjectOfType<Weapon>();
    }
    
    private void OnCollisionEnter2D(Collision2D collision) {
        // Saat Bullet bertabrakan, kembalikan ke Object Pool
        ReturnToPool();
    }

    private void OnBecameInvisible() {
        // Saat Bullet keluar dari layar, kembalikan ke Object Pool
        ReturnToPool();
    }

    public void ReturnToPool() {
        if (weapon != null) {
            weapon.ReturnBulletToPool(this); 
            gameObject.SetActive(false); 
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        HitboxComponent hitbox = other.GetComponent<HitboxComponent>();
        if (hitbox != null && other.CompareTag("Enemy"))
        {
            hitbox.Damage(damage);  // panggil metode damage pada enemy
        }
    }
}
