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
        return null;
    }

    public void Exit(EnemyStateMachineData enemyStateMachineData)
    {
        Debug.Log("EnemyChaseState Exit");
    }
}
