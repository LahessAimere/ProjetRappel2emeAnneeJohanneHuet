using UnityEngine;

public class TestStateMachine : MonoBehaviour
{
    [SerializeField] private int _healthValue;
    
    private IState _currentState;
    private TestStateMachineData testStateMachineData;
    
   private void Start()
   { 
       testStateMachineData = new TestStateMachineData()
       {
           healthValue = _healthValue,
       }; 
       _currentState = new StartState();
       _currentState.Enter(testStateMachineData); 
       if (_currentState != null)
       {
           TransitionTo(new StartState());
       }
    }
    
    private void Update()
    {
        IState nextState = _currentState.Update(testStateMachineData);
        if (_currentState != null)
        {
            TransitionTo(nextState);
        }
    }

    private void TransitionTo(IState nextState)
    {
        if (_currentState != null)
        {
            _currentState.Exit(testStateMachineData);
        }
        _currentState = nextState;
        _currentState.Enter(testStateMachineData);
    }
}