using Features.GameCells.Scripts;
using Features.GameCells.Scripts.Observer;
using Features.Level.Data;
using Features.Score.Scripts;
using Features.Services.UI.Factory;
using Features.Services.UI.Windows;

namespace Features.Level.Scripts
{
  public class LevelFlow
  {
    private readonly ScoreFlowObserver scoreFlowObserver;
    private readonly GameCellsObserver gameCellsObserver;
    private readonly IWindowsService windowsService;
    private readonly LevelSettings settings;

    public LevelFlow(ScoreFlowObserver scoreFlowObserver, GameCellsObserver gameCellsObserver, IWindowsService windowsService, LevelSettings settings)
    {
      this.scoreFlowObserver = scoreFlowObserver;
      this.gameCellsObserver = gameCellsObserver;
      this.windowsService = windowsService;
      this.settings = settings;
    }

    public void PrepareLevel()
    {
      windowsService.Open(WindowId.HUD);
      gameCellsObserver.SpawnCells(settings.CellsForSpawn);
    }

    public void Start()
    {
      
    }

    public void Restart()
    {
      
    }

    public void FinishGame()
    {
      
    }
  }
}