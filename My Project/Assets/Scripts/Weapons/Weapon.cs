using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Weapon : MonoBehaviour
{
    [Header("Weapon Stats")]
    [SerializeField] private float shootingInterval = 1f;

    [Header("Bullets")]
    public Bullet bullet;  
    [SerializeField] private Transform bulletSpawnPoint;  // Tempat Spawn Bullet

    [Header("Bullet Pool")]
    private IObjectPool<Bullet> objectPool;  // Object Pool untuk Bullet
    private readonly bool collectionCheck = false;
    private readonly int defaultCapacity = 30;
    private readonly int maxSize = 100;

    private float timer;
    public Transform parentTransform;

    private void Awake()
    {
        // membuat object pool untuk Bullet
        objectPool = new ObjectPool<Bullet>(
            CreateBullet,
            OnBulletGet,
            OnBulletRelease,
            OnBulletDestroy,
            collectionCheck,
            defaultCapacity,
            maxSize
        );
    }

    private Bullet CreateBullet()
    {
        // membuat Bullet baru dan menyembunyikannya
        Bullet newBullet = Instantiate(bullet, bulletSpawnPoint.position, bulletSpawnPoint.rotation, parentTransform);
        newBullet.gameObject.SetActive(false);
        return newBullet;
    }

    private void OnBulletGet(Bullet bullet)
    {
    //     if (bullet == null)
    // {
    //     Debug.LogWarning("Bullet is null. Skip.");
    //     return;
    // }
        bullet.transform.position = bulletSpawnPoint.position;
        bullet.transform.rotation = bulletSpawnPoint.rotation;
        bullet.gameObject.SetActive(true);
        // Mengatur ulang kecepatan Rigidbody bullet saat diambil dari pool
        bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(0, bullet.bulletSpeed);
    }

    private void OnBulletRelease(Bullet bullet)
    {
        bullet.gameObject.SetActive(false);  // menyembunyikan Bullet ketika tidak digunakan
    }

    private void OnBulletDestroy(Bullet bullet)
    {
        Destroy(bullet.gameObject);  // menghancurkan Bullet
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= shootingInterval)
        {
            Shoot();  // menembak setiap interval waktu
            timer = 0f;
        }
    }

    private void Shoot()
    {
        // mendapatkan Bullet dari Object Pool lalu shoot
        Bullet bulletInstance = objectPool.Get();
    }

    public void ReturnBulletToPool(Bullet bullet) {
        objectPool.Release(bullet);
    }

}
