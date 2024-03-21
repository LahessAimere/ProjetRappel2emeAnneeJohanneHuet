using UnityEngine;

public class EnemyStateMachine : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _shootInterval;
    [SerializeField] private float _detectionRange = 5f;
    [SerializeField] private EnemyMovement _enemyMovement;
    [SerializeField] private EnemyShoot _enemyShoot;
    [SerializeField] private EnemyChasePlayer _enemyChasePlayer;
    [SerializeField] private Bullet _bullet;
    
    private IEnemyState _currentState;
    private EnemyStateMachineData enemyStateMachineData;
    
   private void Start()
   { 
       enemyStateMachineData = new EnemyStateMachineData()
       {
           moveSpeed = _moveSpeed,
           enemyMovement = _enemyMovement,
           enemyShoot = _enemyShoot,
           shootInterval = _shootInterval,
           enemyChasePlayer = _enemyChasePlayer,
           bullet = _bullet,
       }; 
       TransitionTo(new EnemyIdleState());
    }
    
    private void Update()
    { 
        GameObject playerObject = GameObject.FindWithTag("Player");

        if (playerObject != null)
        {
            Transform playerTransform = playerObject.transform;
            bool isPlayerInRange = Vector3.Distance(transform.position, playerTransform.position) <= _detectionRange;

            if (isPlayerInRange)
            {
                TransitionTo(new EnemyChaseState());
            }
            else
            {
                TransitionTo(new EnemyIdleState());
            }
        } 
        else
        {
            Debug.LogWarning("Player object not found!");
        }
        
        IEnemyState nextState = _currentState.Update(enemyStateMachineData);
        if (nextState != null)
        { 
            TransitionTo(nextState);
        }
    }

    private void TransitionTo(IEnemyState nextState)
    {
        if (_currentState != null)
        {
            _currentState.Exit(enemyStateMachineData);
        }
        _currentState = nextState;
        _currentState.Enter(enemyStateMachineData);
    }
}