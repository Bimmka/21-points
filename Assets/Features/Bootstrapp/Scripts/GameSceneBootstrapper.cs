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
    }

    public override void InstallBindings()
    {
      BindUIFactory();
    }

    private void ResolveUIFactory() => 
      Container.Resolve<IUIFactory>();

    private void BindUIFactory() =>
      Container.BindFactoryCustomInterface<BaseWindow, UIFactory, IUIFactory>().AsSingle();
  }
}