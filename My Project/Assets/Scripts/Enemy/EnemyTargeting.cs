using System.Collections;
using UnityEngine;

public class EnemyTargeting : Enemy
{
    public Transform player;
    public float speed = 5f;
    private bool isHidden = false;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (isHidden || player == null) 
        {
            return;  
        }
        // bergerak menuju player
        Vector2 direction = (player.position - transform.position).normalized;
        transform.Translate(direction * speed * Time.deltaTime);
        // sembunyikan jika menyentuh player
        if (Vector2.Distance(transform.position, player.position) < 0.5f)
        {
            HideEnemy();
        }
    }

    void HideEnemy()
    {
        isHidden = true;
        spriteRenderer.enabled = false; // Sembunyikan visual
        StartCoroutine(RespawnEnemy(2f));
    }

    IEnumerator RespawnEnemy(float delay)
    {
        yield return new WaitForSeconds(delay);
        spriteRenderer.enabled = true; // Munculkan visual
        isHidden = false; // Reset status
    }
}
