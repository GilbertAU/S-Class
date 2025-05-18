using UnityEngine;

public class EnemyLowState : EnemyState
{
    private float lowDuration = 2f;
    private float lowTimer;

    public EnemyLowState(Enemy enemy, EnemyStateMachine enemyStateMachine) : base(enemy, enemyStateMachine)
    {
    }

    public override void EnterState()
    {
        lowTimer = lowDuration;
        enemy.RB.velocity = Vector2.zero;

        if (enemy.SpriteRenderer != null)
            enemy.SpriteRenderer.color = Color.red;

        Debug.Log("Enemy is low, entered STUN state");
    }

    public override void FrameUpdate()
    {
        lowTimer -= Time.deltaTime;

        if (lowTimer <= 0f)
        {
            enemyStateMachine.ChangeState(enemy.IdleState);
            Debug.Log("Enemy exited STUN state");
        }
    }

    public override void ExitState()
    {
        if (enemy.SpriteRenderer != null)
            enemy.SpriteRenderer.color = Color.white;
    }
}
