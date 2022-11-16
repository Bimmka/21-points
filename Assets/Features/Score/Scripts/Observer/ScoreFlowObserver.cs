using Features.GameCells.Scripts.Cell;
using Features.GameCells.Scripts.Observer;
using Features.GameStates;
using Features.Score.Scripts.Calculator;
using Features.Score.Scripts.Count;
using Features.Score.Scripts.Data;
using Features.Services.Cleanup;
using UniRx;

namespace Features.Score.Scripts.Observer
{
  public class ScoreFlowObserver : ICleanup
  {
    private readonly GameScore gameScore;
    private readonly PickedCellScoreCounter pickedCellScoreCounter;
    private readonly ScoreSettings settings;
    private readonly CellScoreCalculator calculator;
    private readonly GameCellsObserver gameCellsObserver;

    private readonly CompositeDisposable disposable;

    public readonly ReactiveCommand Filled;
    public readonly ReactiveCommand ResetedCellsScore;

    public ScoreFlowObserver(GameScore gameScore, PickedCellScoreCounter pickedCellScoreCounter, ScoreSettings settings, CellScoreCalculator calculator,
      GameCellsObserver gameCellsObserver, ICleanupService cleanupService)
    {
      disposable = new CompositeDisposable();
      Filled = new ReactiveCommand();
      ResetedCellsScore = new ReactiveCommand();
      
      this.gameScore = gameScore;
      this.settings = settings;
      this.calculator = calculator;

      gameCellsObserver.PickedCells.ObserveAdd().Subscribe(OnAddPickedCell).AddTo(disposable);
      gameCellsObserver.PickedCells.ObserveRemove().Subscribe(OnRemovePickedCell).AddTo(disposable);
      this.gameScore.Score.Subscribe(OnChangeGameScore).AddTo(disposable);
      this.pickedCellScoreCounter = pickedCellScoreCounter;
      this.pickedCellScoreCounter.Score.Subscribe(OnChangeCellScore).AddTo(disposable);
      
      cleanupService.Register(this);
    }

    public void Cleanup()
    {
      disposable.Clear();
    }

    public void ResetAllScore()
    {
      gameScore.ResetScore();
      ResetPickedCellScore();
    }

    public void ApplyChangeScore()
    {
      if (pickedCellScoreCounter.Score.Value > settings.MinBoundPoints)
        gameScore.DecreaseScore(calculator.DecreasedScore(pickedCellScoreCounter.Score.Value));
      else if (pickedCellScoreCounter.Score.Value == settings.MinBoundPoints)
        gameScore.AddScore(pickedCellScoreCounter.Score.Value);

      ResetPickedCellScore();
    }

    private void ResetPickedCellScore() => 
      pickedCellScoreCounter.ResetScore();

    private void OnChangeCellScore(int value)
    {
      if (value >= settings.MinBoundPoints) 
        NotifyAboutReachBoundsScore();
    }

    private void OnChangeGameScore(int value)
    {
      if (value >= settings.PointsToWin)
        Filled.Execute();
    }

    private void OnAddPickedCell(CollectionAddEvent<GameCell> cell) => 
      pickedCellScoreCounter.AddScore(cell.Value.Value);

    private void OnRemovePickedCell(CollectionRemoveEvent<GameCell> cell) => 
      pickedCellScoreCounter.DecreaseScore(cell.Value.Value);

    private void NotifyAboutReachBoundsScore() => 
      ResetedCellsScore.Execute();
  }
}