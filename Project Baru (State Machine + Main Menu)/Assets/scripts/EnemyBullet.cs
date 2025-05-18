using JetBrains.Annotations;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public int damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (collision.TryGetComponent<IDamageable>(out IDamageable damageable))
            {
                damageable.Damage(damage);
            }

            Destroy(gameObject);
        }
    }
}
