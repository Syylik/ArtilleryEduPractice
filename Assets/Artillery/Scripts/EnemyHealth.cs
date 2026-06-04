using UnityEngine;

public class EnemyHealth : Health
{
    protected override void Die()
    {
        LevelEventBus.Instance.OnEnemyDie?.Invoke();
        base.Die();
    }
}
