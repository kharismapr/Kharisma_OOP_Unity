using System.Collections;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(HitboxComponent))]
public class InvincibilityComponent : MonoBehaviour
{
    [SerializeField] private int blinkingCount = 7;
    [SerializeField] private float blinkInterval = 0.1f;
    [SerializeField] private Material blinkMaterial;

    private SpriteRenderer spriteRenderer;
    private Material originalMaterial;
    private bool isInvincible = false;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalMaterial = spriteRenderer.material;
    }

    public void TriggerInvincibility()
    {
        if (!isInvincible)
        {
            StartCoroutine(InvincibilityCoroutine());
        }
    }

    private IEnumerator InvincibilityCoroutine()
    {
        isInvincible = true;

        for (int i = 0; i < blinkingCount; i++)
        {
            spriteRenderer.material = blinkMaterial;
            yield return new WaitForSeconds(blinkInterval / 2);
            spriteRenderer.material = originalMaterial;
            yield return new WaitForSeconds(blinkInterval / 2);
        }
        spriteRenderer.material = originalMaterial;
        isInvincible = false;
    }

    public bool IsInvincible()
    {
        return isInvincible;
    }
}
