using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;


public class EnemyBoss : Enemy
{
    public float speed = 5f;
    public GameObject projectile;
    public float shootingInterval = 1f;
    private float timer;


    private IObjectPool<Bullet> objectPool;


    private Vector2 moveDirection;
    private float leftBound = -11f;
    private float rightBound = 11f;


    void Start()
    {
        transform.position = new Vector2(0, 1f);
        timer = shootingInterval;
        moveDirection = Random.Range(0, 2) == 0 ? Vector2.left : Vector2.right;


        objectPool = new ObjectPool<Bullet>(
            CreateBullet,
            OnBulletGet,
            OnBulletRelease,
            OnBulletDestroy
        );
    }


    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= shootingInterval)
        {
            Shoot();
            timer = 0f;
        }
        Move();
    }


    void Move()
    {
        transform.Translate(moveDirection * speed * Time.deltaTime);
        if (transform.position.x < leftBound || transform.position.x > rightBound)
        {
            moveDirection = -moveDirection;
        }
    }


    private Bullet CreateBullet()
    {
        Bullet newBullet = Instantiate(projectile, transform.position, transform.rotation).GetComponent<Bullet>();
        newBullet.gameObject.SetActive(false); // Matikan bullet saat dibuat
        return newBullet;
    }


    private void OnBulletGet(Bullet bullet)
    {
        bullet.transform.position = transform.position;
        bullet.transform.rotation = transform.rotation;
        bullet.gameObject.SetActive(true);


        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = new Vector2(0, -bullet.bulletSpeed);
        }
    }


    private void OnBulletRelease(Bullet bullet)
    {
        bullet.gameObject.SetActive(false); // Matikan bullet saat dilepaskan
    }


    private void OnBulletDestroy(Bullet bullet)
    {
        Destroy(bullet.gameObject); // Hancurkan bullet jika sudah tidak digunakan
    }


    void Shoot()
    {
        Bullet bulletInstance = objectPool.Get();
        bulletInstance.transform.position = transform.position;
    }


    public void ReturnBulletToPool(Bullet bullet)
    {
        objectPool.Release(bullet);
    }
}
