using Features.GameCells.Scripts;
using Features.Level.Scripts;
using Features.Score.Scripts;
using Features.Services.UI.Factory.BaseUI;
using Features.UI.Windows.Base;
using Zenject;

namespace Features.Bootstrapp.Scripts
{
  public class GameSceneBootstrapper : MonoInstaller
  {
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
  }
}