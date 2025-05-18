using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRecoveryState : EnemyState
{
    private float healAmount = 1f;
    private float healInterval = 2f;
    private float healTimer;

    public EnemyRecoveryState(Enemy enemy, EnemyStateMachine enemyStateMachine) : base(enemy, enemyStateMachine)
    {
    }

    public override void EnterState()
    {
        healTimer = 0f;
    }

    public override void FrameUpdate()
    {
        if (enemy.CurrentHealth < enemy.MaxHealth * 0.8f)
        {
            healTimer += Time.deltaTime;
            if (healTimer >= healInterval)
            {
                healTimer = 0f;
                enemy.CurrentHealth = Mathf.Min(enemy.CurrentHealth + healAmount, enemy.MaxHealth);
                Debug.Log(enemy.CurrentHealth);
            }
        }
        else
        {
            if (enemy.IsAgroed)
                enemyStateMachine.ChangeState(enemy.ChaseState);
            else
                enemyStateMachine.ChangeState(enemy.IdleState);
        }
    }

    public override void ExitState()
    {
        
    }
}