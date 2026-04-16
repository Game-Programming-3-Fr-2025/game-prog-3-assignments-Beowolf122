using UnityEngine;
using UnityEngine.UI; // Required for Image component

public class HealthBarManager : MonoBehaviour
{
    public Image healthBarFillImage; // Assign the fill image in the Inspector
    public float maxHealth = 100f;
    private float currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthBar(); // Initial update
    }

    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;
        currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth); // Ensure health stays within bounds
        UpdateHealthBar();
    }

    public void Heal(float healAmount)
    {
        currentHealth += healAmount;
        currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth); // Ensure health stays within bounds
        UpdateHealthBar();
    }

    void UpdateHealthBar()
    {
        if (healthBarFillImage != null)
        {
            healthBarFillImage.fillAmount = currentHealth / maxHealth;
        }
    }
}
