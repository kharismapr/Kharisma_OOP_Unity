using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    // public int level;
    private Rigidbody2D rb;
    public SpriteRenderer spriteRenderer;
    private HitboxComponent hitboxComponent;
    public int damage = 10;


    void Awake()
    {
        hitboxComponent = GetComponent<HitboxComponent>();
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    private void OnTriggerEnter2D(Collider2D other)
{
    HitboxComponent hitbox = other.GetComponent<HitboxComponent>();
    if (hitbox != null && other.CompareTag("Player"))
    {
         hitbox.Damage(damage);  // panggil metode damage pada enemy
    }
 }
}
