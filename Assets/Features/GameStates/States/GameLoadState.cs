using Features.GameConstants;
using Features.GameStates.States.Interfaces;
using Features.SceneLoading.Scripts;
using Zenject;

namespace Features.GameStates.States
{
  public class GameLoadState : IState
  {
    private readonly IGameStateMachine gameStateMachine;
    private readonly ISceneLoader sceneLoader;

    [Inject]
    public GameLoadState(IGameStateMachine gameStateMachine, ISceneLoader sceneLoader)
    {
      this.gameStateMachine = gameStateMachine;
      this.sceneLoader = sceneLoader;

      gameStateMachine.Register(this);
    }

    public void Enter() => 
      sceneLoader.Load(Constants.GameSceneName, onLoaded: OnLoad);

    public void Exit() { }

    private void OnLoad() => 
      gameStateMachine.Enter<GameLoopState>();
  }
}