using UnityEngine;

public class EnemyChaseState : IEnemyState
{
    public void Enter(EnemyStateMachineData enemyStateMachineData)
    {
        Debug.Log("EnemyChaseState Enter");
    }

    public IEnemyState Update(EnemyStateMachineData enemyStateMachineData)
    {
        enemyStateMachineData.enemyChasePlayer.ChasePlayer();
        if (enemyStateMachineData.player != null)
        {
            Transform playerTransform = enemyStateMachineData.player.transform;
            bool isPlayerInRange = Vector3.Distance(enemyStateMachineData.enemyTransform.position, playerTransform.position) > 
                                   enemyStateMachineData.detectionRange;

            if (isPlayerInRange)
            {
                Debug.Log("Transition to ChaseState");
                return new EnemyIdleState();
            }
        }
        return null;
    }

    public void Exit(EnemyStateMachineData enemyStateMachineData)
    {
        Debug.Log("EnemyChaseState Exit");
    }
}
