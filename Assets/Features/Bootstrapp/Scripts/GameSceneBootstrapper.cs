using Features.GameCells.Data;
using Features.GameCells.Scripts;
using Features.GameCells.Scripts.Cell;
using Features.GameCells.Scripts.Observer;
using Features.GameCells.Scripts.Panel;
using Features.GameCells.Scripts.Spawn.Factory;
using Features.GameCells.Scripts.Spawn.Spawner;
using Features.Level.Data;
using Features.Level.Scripts;
using Features.Score.Scripts;
using Features.Score.Scripts.Calculator;
using Features.Score.Scripts.Count;
using Features.Score.Scripts.Data;
using Features.Score.Scripts.Observer;
using Features.Services.Cleanup;
using Features.Services.UI.Factory.BaseUI;
using Features.UI.Windows.Base;
using UnityEngine;
using Zenject;

namespace Features.Bootstrapp.Scripts
{
  public class GameSceneBootstrapper : MonoInstaller
  {
    [SerializeField] private LevelSettings levelSettings;
    [SerializeField] private GamePanel gamePanel;
    [SerializeField] private GamePanelSettings gamePanelSettings;
    [SerializeField] private GameCell gameCell;
    [SerializeField] private GameCellSpawnSettings gameCellSpawnSettings;
    [SerializeField] private ScoreSettings scoreSettings;
    [SerializeField] private LevelObserver levelObserver;

    public override void Start()
    {
      base.Start();
      ResolveUIFactory();
      StartLevel(ResolveLevelFlow());
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
      BindGameScore();
      BindCellScore();
      BindScoreCalculator();
      BindCleanupService();
      BindLevelObserver();
    }

    private LevelObserver ResolveLevelFlow() => 
      Container.Resolve<LevelObserver>();

    private void ResolveUIFactory() => 
      Container.Resolve<IUIFactory>();

    private void StartLevel(LevelObserver levelObserver) => 
      levelObserver.StartGame();

    private void BindLevelObserver() => 
      Container.Bind<LevelObserver>().FromComponentInNewPrefab(levelObserver).AsSingle();

    private void BindUIFactory() =>
      Container.BindFactoryCustomInterface<BaseWindow, UIFactory, IUIFactory>().AsSingle();

    private void BindLevel() => 
      Container.Bind<LevelFlow>().ToSelf().FromNew().AsSingle().WithArguments(levelSettings);

    private void BindScoreFlow() => 
      Container.Bind<ScoreFlowObserver>().ToSelf().FromNew().AsSingle().WithArguments(scoreSettings);

    private void BindGameCellsObserver() => 
      Container.Bind<GameCellsObserver>().ToSelf().FromNew().AsSingle();

    private void BindGameCellsSpawner() => 
      Container.Bind<GameCellSpawner>().ToSelf().FromNew().AsSingle().WithArguments(gameCell, gameCellSpawnSettings);

    private void BindGameCellsFactory() => 
      Container.BindFactoryCustomInterface<GameCell, GameCellFactory, IGameCellFactory>().AsSingle();

    private void BindGamePanel() => 
      Container.Bind<GamePanel>().ToSelf().FromComponentInNewPrefab(gamePanel).AsSingle().WithArguments(gamePanelSettings);

    private void BindGameScore() => 
      Container.Bind<GameScore>().ToSelf().FromNew().AsSingle();

    private void BindCellScore() => 
      Container.Bind<PickedCellScoreCounter>().ToSelf().FromNew().AsSingle();

    private void BindScoreCalculator() => 
      Container.Bind<CellScoreCalculator>().ToSelf().FromNew().AsSingle();

    private void BindCleanupService() => 
      Container.Bind<ICleanupService>().To<CleanupService>().FromNew().AsSingle();
  }
}