using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] private float speed = 0.1f;
    [SerializeField] private float rotateSpeed = 0.1f;

    private Vector2 newPosition;
    private SpriteRenderer spriteRenderer;
    private Collider2D portalCollider;

    void Start()
    {
        // ambil komponen
        spriteRenderer = GetComponent<SpriteRenderer>();
        portalCollider = GetComponent<Collider2D>();
        ChangePosition();
    }

    void Update()
    {
        if (Vector2.Distance(transform.position, newPosition) < 0.5f)
            ChangePosition();

        // mancari Player berdasarkan tag
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        bool HasWeapon = player != null && player.GetComponentInChildren<Weapon>() != null;

        if (HasWeapon)
        {
            // pengaktifan SpriteRenderer dan Collider agar portal terlihat dan bisa ditabrak
            spriteRenderer.enabled = true;
            portalCollider.enabled = true;
            // pergerakan portal menuju posisi baru
            transform.position = Vector2.MoveTowards(transform.position, newPosition, speed * Time.deltaTime);
            transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime);
        }
        else
        {
            // nonaktifkan SpriteRenderer dan Collider jika player tidak memiliki senjata
            spriteRenderer.enabled = false;
            portalCollider.enabled = false;
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // cek apakah objek yang memasuki trigger memiliki tag "Player"
        if (other.gameObject.CompareTag("Player"))
        {
            LevelManager levelManager = GameManager.Instance.LevelManager;
            //pindah scene
            levelManager.LoadScene("Main");
        }
    }
    private void ChangePosition()
        {
            // Mengatur newPosition secara acak di sekitar area
            float x = Random.Range(-1.0f, 1.0f);
            float y = Random.Range(-2.0f, 3.0f);
            newPosition = new Vector2(x, y);
        }

    
}
