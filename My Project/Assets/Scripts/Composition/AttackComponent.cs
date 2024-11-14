using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class AttackComponent : MonoBehaviour
{
    public Bullet bullet;
    public int damage = 10;

    private void OnTriggerEnter(Collider2D other)
    {
        HitboxComponent hitbox = other.GetComponent<HitboxComponent>();
        
        // Cek jika objek yang tertabrak memiliki HitboxComponent dan bukan objek dengan tag yang sama
        if (hitbox != null && other.CompareTag("Enemy"))
        {
            hitbox.Damage(damage);
        }
    }
}

