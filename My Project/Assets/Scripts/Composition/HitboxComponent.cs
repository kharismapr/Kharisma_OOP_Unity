using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class HitboxComponent : MonoBehaviour
{
    [SerializeField] private HealthComponent health;

    private void Awake()
    {
        if (health == null)
        {
            health = GetComponent<HealthComponent>();  // ambil HealthComponent dari objek yang sama
        }
    }

    public void Damage(Bullet bullet)
    {
        if (bullet != null)
        {
            health.Subtract(bullet.damage);
        }
    }

    public void Damage(int damage)
    {
        health.Subtract(damage);
    }
}

