using System;

public interface IState
{
    public void Enter(TestStateMachineData testStateMachineData)
    {
        throw new System.NotImplementedException();
    }

    public IState Update(TestStateMachineData testStateMachineData)
    {
        throw new System.NotImplementedException();
    }

    public void Exit(TestStateMachineData testStateMachineData)
    {
        throw new System.NotImplementedException();
    }
}
