using Features.GameCells.Scripts;
using Features.Score.Scripts;

namespace Features.Level.Scripts
{
  public class LevelFlow
  {
    private readonly ScoreFlowObserver scoreFlowObserver;
    private readonly GameCellsObserver gameCellsObserver;

    public LevelFlow(ScoreFlowObserver scoreFlowObserver, GameCellsObserver gameCellsObserver)
    {
      this.scoreFlowObserver = scoreFlowObserver;
      this.gameCellsObserver = gameCellsObserver;
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