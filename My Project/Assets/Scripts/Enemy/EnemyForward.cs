using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyForward : Enemy
{
    public float speed = 5f;

    void Start()
    {
        // Spawn dari atas
        transform.position = new Vector2(Random.Range(-8f, 8f), 6f);
    }

    void Update()
    {
        // Gerakan ke bawah
        transform.Translate(Vector2.down * speed * Time.deltaTime);

        // balik arah kalo keluar layar
        if (transform.position.y < -6f || transform.position.y > 6f)
        {
            speed = -speed;
        }
    }
}

