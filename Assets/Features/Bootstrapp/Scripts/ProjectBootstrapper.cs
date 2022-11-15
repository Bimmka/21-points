using Features.GameStates;
using Features.GameStates.States;
using Features.GameStates.States.Interfaces;
using Features.SceneLoading.Scripts;
using Features.Services.Assets;
using Features.Services.Coroutine;
using Features.Services.StaticData;
using Features.Services.UI.Windows;
using UnityEngine;
using Zenject;

namespace Features.Bootstrapp.Scripts
{
  public class ProjectBootstrapper : MonoInstaller, ICoroutineRunner
  {
    [SerializeField] private GameObserver gameObserverPrefab;
    [SerializeField] private LoadingCurtain loadingCurtain;

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
      BindAssetProvider();
      BindStaticDataService();
      BindLoadingCurtain();
      BindCoroutineRunner();
      BindSceneLoader();
      BindWindowsService();
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

    private void BindAssetProvider() => 
      Container.Bind<IAssetProvider>().To<AssetProvider>().FromNew().AsSingle();

    private void BindStaticDataService()
    {
      StaticDataService staticDataService = new StaticDataService();
      staticDataService.Load();
      Container.Bind<IStaticDataService>().To<StaticDataService>().FromInstance(staticDataService).AsSingle();
    }

    private void BindLoadingCurtain() => 
      Container.Bind<LoadingCurtain>().To<LoadingCurtain>().FromComponentInNewPrefab(loadingCurtain).AsSingle();

    private void BindCoroutineRunner() => 
      Container.Bind<ICoroutineRunner>().To<ICoroutineRunner>().FromInstance(this).AsSingle();

    private void BindSceneLoader() => 
      Container.Bind<ISceneLoader>().To<SceneLoader>().FromNew().AsSingle();

    private void BindWindowsService() => 
      Container.Bind<IWindowsService>().To<WindowsService>().FromNew().AsSingle();
  }
}