using Features.GameCells.Scripts;
using Features.GameCells.Scripts.Observer;
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

    public LevelFlow(ScoreFlowObserver scoreFlowObserver, GameCellsObserver gameCellsObserver, IWindowsService windowsService)
    {
      this.scoreFlowObserver = scoreFlowObserver;
      this.gameCellsObserver = gameCellsObserver;
      this.windowsService = windowsService;
    }

    public void PrepareLevel() => 
      windowsService.Open(WindowId.HUD);

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