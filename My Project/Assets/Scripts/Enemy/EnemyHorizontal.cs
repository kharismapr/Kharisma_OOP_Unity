using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHorizontal : Enemy
{
    public float speed = 5f;

    void Start()
    {
        // Tentukan spawn dari kiri atau kanan layar
        float spawnPositionX = Random.Range(0, 2) == 0 ? -10f : 10f;
        transform.position = new Vector2(spawnPositionX, Random.Range(-4f, 4f));
    }

    void Update()
    {
        // Gerakan horizontal
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        // Cek jika sudah keluar layar, balik arah
        if (transform.position.x < -11f || transform.position.x > 11f)
        {
            speed = -speed;
        }
    }
}

