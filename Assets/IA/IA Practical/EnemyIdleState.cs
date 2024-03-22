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

        if (enemyStateMachineData.player != null)
        {
            Transform playerTransform = enemyStateMachineData.player.transform;
            bool isPlayerInRange = Vector3.Distance(enemyStateMachineData.enemyTransform.position, playerTransform.position) <=
                                   enemyStateMachineData.detectionRange;

            if (isPlayerInRange)
            {
                Debug.Log("Transition to ChaseState");
                return new EnemyChaseState();
            }
        }
        return null;
    }

    public void Exit(EnemyStateMachineData enemyStateMachineData)
    {
        Debug.Log("EnemyIdleState Exit");
    }
}
