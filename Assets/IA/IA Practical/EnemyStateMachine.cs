using UnityEngine;
using UnityEngine.Serialization;

public class EnemyStateMachine : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _shootInterval;
    [SerializeField] private EnemyMovement _enemyMovement;
    [SerializeField] private EnemyShoot _enemyShoot;
    [SerializeField] private EnemyChasePlayer _enemyChasePlayer;
    [SerializeField] private GameObject _player;
    [SerializeField] private Transform _EnemyTransform;
    [SerializeField] private float _detectionRange = 5f;
    
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
           player = _player,
           enemyTransform = _EnemyTransform,
           detectionRange = _detectionRange,
       }; 
       TransitionTo(new EnemyIdleState());
    }
    
    private void Update()
    { 
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