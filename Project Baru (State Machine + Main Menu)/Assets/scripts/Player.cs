using UnityEngine;

public class Player : MonoBehaviour, IDamageable
{
    [field: SerializeField] public float MaxHealth { get; set; } = 20f;
    public float CurrentHealth { get; set; }

    void Start()
    {
        CurrentHealth = MaxHealth;
    }

    public void Damage(float damageAmount)
    {
        CurrentHealth -= damageAmount;
        Debug.Log("Player terkena damage. Sisa HP: " + CurrentHealth);
        if (CurrentHealth <= 0f)
        {
            Die();
        }
    }

    public void Die()
    {
        Debug.Log("Player has died.");
    }

    void Update()
    {

    }
}
