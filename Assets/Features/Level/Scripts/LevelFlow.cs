using Features.GameCells.Scripts.Observer;
using Features.Level.Data;
using Features.Score.Scripts.Observer;
using Features.Services.Cleanup;
using Features.Services.UI.Factory;
using Features.Services.UI.Windows;
using UniRx;

namespace Features.Level.Scripts
{
  public class LevelFlow
  {
    private readonly CompositeDisposable disposable;
    
    private readonly ScoreFlowObserver scoreFlowObserver;
    private readonly GameCellsObserver gameCellsObserver;
    private readonly IWindowsService windowsService;
    private readonly LevelSettings settings;
    private readonly ICleanupService cleanupService;

    public LevelFlow(ScoreFlowObserver scoreFlowObserver, GameCellsObserver gameCellsObserver, IWindowsService windowsService, LevelSettings settings, 
      ICleanupService cleanupService)
    {
      disposable = new CompositeDisposable();
      
      this.scoreFlowObserver = scoreFlowObserver;
      this.scoreFlowObserver.Filled.Subscribe(onNext => FinishGame()).AddTo(disposable);
      this.scoreFlowObserver.ResetedCellsScore.Subscribe(onNext => ResetPickedCells()).AddTo(disposable);
      this.gameCellsObserver = gameCellsObserver;
      this.windowsService = windowsService;
      this.settings = settings;
      this.cleanupService = cleanupService;
    }

    public void Cleanup()
    {
      disposable.Clear();
      cleanupService.Cleanup();
      cleanupService.Clear();
    }

    public void PrepareLevel()
    {
      windowsService.Open(WindowId.HUD);
      gameCellsObserver.SpawnCells(settings.CellsForSpawn);
      gameCellsObserver.LockAllCells();
    }

    public void Start()
    {
      gameCellsObserver.UnlockAllCells();
    }

    public void Restart()
    {
      scoreFlowObserver.ResetAllScore();
      gameCellsObserver.RefreshAllCellsValue();
      gameCellsObserver.UnlockAllCells();
    }

    private void FinishGame()
    {
      gameCellsObserver.LockAllCells();
      windowsService.Open(WindowId.GameFinish);
    }

    private void ResetPickedCells()
    {
      gameCellsObserver.LockAllCells();
      gameCellsObserver.DisableClickedCells(OnDisableClickedCells);
    }

    private void OnDisableClickedCells() => 
      gameCellsObserver.RespawnClickedCells(OnRespawnClickedCells);

    private void OnRespawnClickedCells()
    {
      gameCellsObserver.UnlockAllCells();
      gameCellsObserver.ResetClickedCells();
      scoreFlowObserver.ApplyChangeScore();
    }
  }
}