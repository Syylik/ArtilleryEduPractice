using UnityEngine;

public abstract class Health : MonoBehaviour
{
    private int _health;
    [SerializeField] private int maxHealth = 10;

    private void Awake()
    {
        _health = maxHealth;
    }

    public virtual void TakeDamage(int damage)
    {
        _health -= damage;
        _health = Mathf.Clamp(_health, 0, maxHealth);
        if(_health <= 0)
        {
            Die();
        }
    }

    protected virtual void Die()
    {
        Destroy(gameObject);
    }
}