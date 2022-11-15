using Features.GameStates.States.Interfaces;
using Features.Services.UI.Windows;

namespace Features.GameStates.States
{
  public class GameFinishState : IState
  {
    private readonly IWindowsService windowsService;

    public GameFinishState(IGameStateMachine gameStateMachine, IWindowsService windowsService)
    {
      this.windowsService = windowsService;
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