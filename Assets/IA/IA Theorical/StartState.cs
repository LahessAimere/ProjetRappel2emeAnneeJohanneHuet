public class StartState : IState
{
    public void Enter(TestStateMachineData testStateMachineData)
    {
        throw new System.NotImplementedException();
    }

    public IState Update(TestStateMachineData testStateMachineData)
    {
        return new IdleState();
    }

    public void Exit(TestStateMachineData testStateMachineData)
    {
        throw new System.NotImplementedException();
    }
}
