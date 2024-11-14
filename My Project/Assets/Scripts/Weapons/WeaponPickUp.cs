using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    [SerializeField] private Weapon weaponHolder;  // Prefab senjata yang akan diinstansiasi
    private Weapon weapon;  // Referensi ke senjata yang telah diinstansiasi

    private void Awake()
    {
        weapon = Instantiate(weaponHolder);  // Mmembuat salinan senjata dari prefab
    }

    private void Start()
    {
        if (weapon != null)
        {
            // nonaktifkan senjata saat baru mulai
            weapon.enabled = false;
            TurnVisual(false);  // menonaktifkan tampilan senjata agar tidak terlihat
            weapon.transform.SetParent(transform, false);  // menjadikan pickup sebagai parent
            weapon.transform.localPosition = transform.position;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player has pickup the weapon");

            // Mencari senjata yang sudah dimiliki Player (jika ada)
            Weapon playerWeapon = other.gameObject.GetComponentInChildren<Weapon>();

            if (playerWeapon != null)
            {
                // Menonaktifkan senjata lama
                playerWeapon.enabled = false;  // Nonaktifkan komponen Weapon dari senjata lama
                playerWeapon.transform.SetParent(playerWeapon.parentTransform);  // Atur parent ke original
                playerWeapon.transform.localPosition = new Vector3(0, 0, 1);  // Reset posisi
                TurnVisual(false, playerWeapon);  // Menonaktifkan tampilan senjata lama
            }

            // Mengaktifkan senjata baru untuk pemain
            weapon.enabled = true;  // Aktifkan komponen Weapon pada senjata baru
            weapon.transform.SetParent(other.transform);  // Jadikan Player sebagai parent senjata
            weapon.transform.localPosition = new Vector3(0, 0, 1);  // Reset posisi senjata di player
            TurnVisual(true, weapon);  // Menampilkan senjata baru
        }
    }

    // Mengaktifkan atau menonaktifkan semua komponen render dalam weapon
    private void TurnVisual(bool on)
    {
        if (weapon != null)
        {
            var renderers = weapon.GetComponentsInChildren<Renderer>();
            foreach (var renderer in renderers)
            {
                renderer.enabled = on;
            }
        }
    }

    // Overload untuk TurnVisual, menerima parameter weapon
    private void TurnVisual(bool on, Weapon weapon)
    {
        if (weapon != null)
        {
            var renderers = weapon.GetComponentsInChildren<Renderer>();
            foreach (var renderer in renderers)
            {
                renderer.enabled = on;
            }
        }
    }
}
