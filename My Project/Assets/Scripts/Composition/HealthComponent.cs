using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    public float maxHealth = 700f;
    private float health;

    private void Awake()
    {
        health = maxHealth;  
    }

    public float Health => health;  // Getter  health

    // Setter Substract
    public void Subtract(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);  // destroy kalau health <= 0
        }
    }
}
