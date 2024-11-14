using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Vector2 maxSpeed;
    [SerializeField] private Vector2 timeToFullSpeed;
    [SerializeField] private Vector2 timeToStop;
    [SerializeField] private Vector2 stopClamp;

    private Vector2 moveDirection;
    private Vector2 moveVelocity;
    private Vector2 moveFriction;
    private Vector2 stopFriction;
    private Rigidbody2D rb;
    private Vector2 ppos;
    // Tambahkan referensi kamera dan batas layar
    // private Camera mainCamera;
    // private Vector2 screenBounds;

    private void Start()
    {
        // Mengambil komponen Rigidbody2D
        rb = GetComponent<Rigidbody2D>();

        // Perhitungan awal untuk moveVelocity, moveFriction, dan stopFriction
        moveVelocity = 2 * maxSpeed / timeToFullSpeed;
        moveFriction = -2 * maxSpeed / (timeToFullSpeed * timeToFullSpeed);
        stopFriction = -2 * maxSpeed / (timeToStop * timeToStop);

        // // Inisialisasi main camera dan batas layar
        // mainCamera = Camera.main;
        // screenBounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z));

    }

    public void Move()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
        moveDirection = new Vector2(moveX, moveY).normalized;

        // Mengatur kecepatan berdasarkan input dan batas kecepatan maksimum
        Vector2 targetVelocity = new Vector2(
            moveDirection.x * maxSpeed.x,
            moveDirection.y * maxSpeed.y
        );

        // Mengatur kecepatan player menggunakan moveVelocity
        Vector2 currentVelocity = rb.velocity;

        currentVelocity.x = Mathf.MoveTowards(currentVelocity.x, 
        targetVelocity.x, moveVelocity.x * Time.fixedDeltaTime);
        
        currentVelocity.y = Mathf.MoveTowards(currentVelocity.y, 
        targetVelocity.y, moveVelocity.y * Time.fixedDeltaTime);

        // Pengaturan untuk membatasi kecepatan
        currentVelocity.x = Mathf.Clamp(currentVelocity.x, -stopClamp.x, stopClamp.x);
        currentVelocity.y = Mathf.Clamp(currentVelocity.y, -stopClamp.y, stopClamp.y);

        rb.velocity = currentVelocity;

        // Panggil MoveBound untuk membatasi posisi pemain
        MoveBound();
    }

    public Vector2 GetFriction()
    {
        // memberikan nilai gaya gesek yang sesuai berdasarkan kondisi pesawat sedang bergerak atau tidak
        if (moveDirection.magnitude > 0){
            return moveFriction;
        }
        else{
            return stopFriction;
        }
    }

    public void MoveBound()
    {
        ppos = Camera.main.WorldToViewportPoint(transform.position);
        ppos.x = Mathf.Clamp(ppos.x, 0.01f, 0.99f);
        ppos.y = Mathf.Clamp(ppos.y, -0.01f, 0.95f);
        transform.position = Camera.main.ViewportToWorldPoint(ppos) + new Vector3(0, 0, 10);
    }

    public bool IsMoving()
    {
        // Mengembalikan true jika Player bergerak
        return rb.velocity.magnitude > 0;
    }
}
