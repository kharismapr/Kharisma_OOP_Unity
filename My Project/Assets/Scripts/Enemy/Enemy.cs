using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // public int level;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private HitboxComponent hitboxComponent;

    void Awake()
    {
        hitboxComponent = GetComponent<HitboxComponent>();
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
}
