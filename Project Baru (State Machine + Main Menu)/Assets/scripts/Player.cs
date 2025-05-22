using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour, IDamageable
{
    [field: SerializeField] public float MaxHealth { get; set; } = 100f;
    public float CurrentHealth { get; set; }

    public HealthBar healthBar;
    //public Animator animator;

    void Start()
    {
        CurrentHealth = MaxHealth;
        healthBar.SetMaxHealth(CurrentHealth);
    }

    public void Damage(float damageAmount)
    {
        CurrentHealth -= damageAmount;
        //animator.SetBool("Player_Hurt", true);
        Debug.Log("Player terkena damage. Sisa HP: " + CurrentHealth);

        healthBar.SetHealth(CurrentHealth);
        if (CurrentHealth <= 0f)
        {
            Die();
        }
    }

    public void Die()
    {
        gameObject.SetActive(false);
        Debug.Log("Player has died.");
    }
}
