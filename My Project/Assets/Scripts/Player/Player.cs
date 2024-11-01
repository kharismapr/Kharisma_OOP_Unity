using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private PlayerMovement playerMovement;
    private Animator animator;

    public static Player Instance { get; private set; }

    private void Awake()
    {
        // Penerapan Singleton
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        // Mengambil komponen PlayerMovement dan Animator dari objek
        playerMovement = GetComponent<PlayerMovement>();
        animator = GameObject.Find("EngineEffect").GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        // Memanggil method Move dari PlayerMovement untuk menggerakkan player
        playerMovement.Move();
    }

    private void LateUpdate()
    {
        // Mengatur parameter IsMoving di Animator sesuai dengan status pergerakan
        animator.SetBool("IsMoving", playerMovement.IsMoving());
    }
}