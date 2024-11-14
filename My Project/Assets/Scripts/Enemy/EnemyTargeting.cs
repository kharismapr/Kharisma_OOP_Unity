using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTargeting : Enemy
{
    public Transform player;
    public float speed = 4f;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        // Bergerak menuju player
        Vector2 direction = (player.position - transform.position).normalized;
        transform.Translate(direction * speed * Time.deltaTime);

        // Hapus jika menyentuh player
        if (Vector2.Distance(transform.position, player.position) < 0.5f)
        {
            Destroy(gameObject);
        }
    }
}

