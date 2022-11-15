using Features.GameStates.States.Interfaces;

namespace Features.GameStates.States
{
  public class GameFinishState : IState
  {
    public GameFinishState(IGameStateMachine gameStateMachine)
    {
      gameStateMachine.Register(this);
    }
    
    public void Enter()
    {
      
    }

    public void Exit()
    {
      
    }
  }
}