using Features.GameStates.States.Interfaces;
using Zenject;

namespace Features.GameStates.States
{
  public class GameLoadState : IState
  {
    private readonly IGameStateMachine gameStateMachine;

    [Inject]
    public GameLoadState(IGameStateMachine gameStateMachine)
    {
      this.gameStateMachine = gameStateMachine;
    
      gameStateMachine.Register(this);
    }

    public void Enter()
    {
    
    }

    public void Exit()
    {
      
    }

    private void OnLoad()
    {
    }
    
  }
}