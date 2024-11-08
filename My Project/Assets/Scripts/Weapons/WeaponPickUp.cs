using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    [SerializeField] private Weapon weaponHolder;
    private Weapon weapon;

    private void Awake()
    {
        weapon = Instantiate(weaponHolder);
        
    }

    private void Start()
    {
        if (weapon != null)
        {
            weapon.enabled = false;
            TurnVisual(false);
            weapon.transform.SetParent(transform, false);
            weapon.transform.localPosition = transform.position;
            
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            Debug.Log("Collide");
            Weapon playerWeapon = other.gameObject.GetComponentInChildren<Weapon>();

            if (playerWeapon != null)
            {
                // Set parent dari weapon menjadi Player
                playerWeapon.transform.SetParent(playerWeapon.parentTransform);
                playerWeapon.transform.localPosition = new(0,0,1);
                playerWeapon.transform.localScale = new (1,1);
                // weapon.transform.parent = other.transform;
                TurnVisual(false, playerWeapon);
            }

            weapon.enabled = true;
            weapon.transform.SetParent(other.transform);
            weapon.transform.localPosition = new(0,0,1);
            TurnVisual(true, weapon);

        }
    }


    private void TurnVisual(bool on)
    {
        // Mengaktifkan atau menonaktifkan semua komponen render dalam weapon
        if (weapon != null)
        {
            var renderers = weapon.GetComponentsInChildren<Renderer>();
            foreach (var renderer in renderers)
            {
                renderer.enabled = on;
            }
        }
    }

    private void TurnVisual(bool on, Weapon weapon)  // overload tambah parameter weapon
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
