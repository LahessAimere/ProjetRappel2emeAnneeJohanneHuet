public class IdleState : IState
{
    public void Enter(TestStateMachineData testStateMachineData)
    {
        throw new System.NotImplementedException();
    }

    public IState Update(TestStateMachineData testStateMachineData)
    {
        if (testStateMachineData.healthValue <= 0)
        {
            
        }
        return null;
    }

    public void Exit(TestStateMachineData testStateMachineData)
    {
        throw new System.NotImplementedException();
    }
}
