using Features.GameCells.Scripts;
using Features.GameCells.Scripts.Cell;
using Features.GameCells.Scripts.Observer;
using Features.GameCells.Scripts.Panel;
using Features.GameCells.Scripts.Spawn.Factory;
using Features.GameCells.Scripts.Spawn.Spawner;
using Features.Level.Scripts;
using Features.Score.Scripts;
using Features.Services.UI.Factory.BaseUI;
using Features.UI.Windows.Base;
using UnityEngine;
using Zenject;

namespace Features.Bootstrapp.Scripts
{
  public class GameSceneBootstrapper : MonoInstaller
  {
    [SerializeField] private GamePanel gamePanel;
    
    public override void Start()
    {
      base.Start();
      ResolveUIFactory();
      LevelFlow levelFlow = ResolveLevelFlow();
      StartLevel(levelFlow);
    }

    public override void InstallBindings()
    {
      BindUIFactory();
      BindLevel();
      BindScoreFlow();
      BindGameCellsObserver();
      BindGameCellsSpawner();
      BindGameCellsFactory();
      BindGamePanel();
    }

    private LevelFlow ResolveLevelFlow() => 
      Container.Resolve<LevelFlow>();

    private void ResolveUIFactory() => 
      Container.Resolve<IUIFactory>();

    private void StartLevel(LevelFlow levelFlow)
    {
      levelFlow.PrepareLevel();
      levelFlow.Start();
    }

    private void BindUIFactory() =>
      Container.BindFactoryCustomInterface<BaseWindow, UIFactory, IUIFactory>().AsSingle();

    private void BindLevel() => 
      Container.Bind<LevelFlow>().ToSelf().FromNew().AsSingle();

    private void BindScoreFlow() => 
      Container.Bind<ScoreFlowObserver>().ToSelf().FromNew().AsSingle();

    private void BindGameCellsObserver() => 
      Container.Bind<GameCellsObserver>().ToSelf().FromNew().AsSingle();

    private void BindGameCellsSpawner() => 
      Container.Bind<GameCellSpawner>().ToSelf().FromNew().AsSingle();

    private void BindGameCellsFactory() => 
      Container.BindFactoryCustomInterface<GameCell, GameCellFactory, IGameCellFactory>().AsSingle();

    private void BindGamePanel() => 
      Container.Bind<GamePanel>().ToSelf().FromComponentInNewPrefab(gamePanel).AsSingle();
  }
}