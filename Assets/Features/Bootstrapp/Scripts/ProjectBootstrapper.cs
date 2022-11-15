using Features.GameStates;
using Features.GameStates.States;
using Features.GameStates.States.Interfaces;
using UnityEngine;
using Zenject;

namespace Features.Bootstrapp.Scripts
{
  public class ProjectBootstrapper : MonoInstaller
  {
    [SerializeField] private GameObserver gameObserverPrefab;

    public override void Start()
    {
      base.Start();
      ResolveGameStates();
      GameObject gameObserver = SpawnGameObserver();
      StartGame(gameObserver);
    }

    public override void InstallBindings()
    {
      BindGameStateMachine();
      BindGameStates();
      BindGame();
    }

    private void ResolveGameStates()
    {
      Container.Resolve<GameFinishState>();
      Container.Resolve<GameLoadState>();
      Container.Resolve<GameLoopState>();
      Container.Resolve<MainMenuState>();
    }

    private GameObject SpawnGameObserver() => 
      Container.InstantiatePrefab(gameObserverPrefab);

    private void StartGame(GameObject gameObserver) => 
      gameObserver.GetComponent<GameObserver>().StartGame();

    private void BindGameStateMachine() => 
      Container.Bind<IGameStateMachine>().To<GameStateMachine>().FromNew().AsSingle();

    private void BindGameStates()
    {
      Container.Bind<GameFinishState>().ToSelf().FromNew().AsSingle();
      Container.Bind<GameLoadState>().ToSelf().FromNew().AsSingle();
      Container.Bind<GameLoopState>().ToSelf().FromNew().AsSingle();
      Container.Bind<MainMenuState>().ToSelf().FromNew().AsSingle();
    }

    private void BindGame() => 
      Container.Bind<Game>().ToSelf().FromNew().AsSingle();
  }
}