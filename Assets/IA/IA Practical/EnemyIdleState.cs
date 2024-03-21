using UnityEngine;

public class EnemyIdleState : IEnemyState
{
    public void Enter(EnemyStateMachineData enemyStateMachineData)
    {
        Debug.Log("EnemyIdleState Enter");
    }

    public IEnemyState Update(EnemyStateMachineData enemyStateMachineData)
    {
        enemyStateMachineData.enemyMovement.Move(enemyStateMachineData.moveSpeed);
        enemyStateMachineData.enemyShoot.ShootRoutine(enemyStateMachineData.shootInterval);
        return null;
    }

    public void Exit(EnemyStateMachineData enemyStateMachineData)
    {
        Debug.Log("EnemyIdleState Exit");
    }
}
