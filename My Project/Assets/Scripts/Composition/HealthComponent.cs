using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HealthComponent : MonoBehaviour
{
    public float maxHealth = 100;
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
        Debug.Log(gameObject.name + " took " + damage + " damage. Remaining health: " + health); // Tampilkan sisa health
        if (health <= 0)
        {
            Destroy(gameObject);  // destroy kalau health <= 0
            Debug.Log("Died!");
        }
    }
}
