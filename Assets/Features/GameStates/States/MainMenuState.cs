using Features.GameStates.States.Interfaces;

namespace Features.GameStates.States
{
  public class MainMenuState : IState
  {

    public MainMenuState(IGameStateMachine gameStateMachine)
    {
      gameStateMachine.Register(this);
    }
    
    public void Enter()
    {
    }

    public void Exit() { }

    private void OnLoaded()
    {
     
    }
  }
}