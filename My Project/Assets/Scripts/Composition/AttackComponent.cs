using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class AttackComponent : MonoBehaviour
{
    public Bullet bullet;
    public int damage;

    private void OnTriggerEnter2D(Collider2D other)
{
    if (other.gameObject.CompareTag(gameObject.tag)) return;

    var hitbox = other.GetComponent<HitboxComponent>();
    var invincibility = other.GetComponent<InvincibilityComponent>();

    if (hitbox != null)
    {
        if (bullet != null)
        {
            hitbox.Damage(bullet.damage);
        }
        else
        {
            hitbox.Damage(damage);
        }
    }

    if (invincibility != null)
    {
        invincibility.TriggerInvincibility();
    }
}

}
