using Features.Score.Scripts.Count;
using Features.UI.Windows.Base;
using UnityEngine;
using Zenject;

namespace Features.UI.Windows.HUD.Scripts
{
  public class HUD : BaseWindow
  {
    [SerializeField] private ScoreDisplayer gameScoreDisplayer;
    [SerializeField] private ScoreDisplayer cellScoreDisplayer;

    [Inject]
    public void Construct(GameScore gameScore, PickedCellScoreCounter cellScoreCounter)
    {
      gameScoreDisplayer.Construct(gameScore);
      cellScoreDisplayer.Construct(cellScoreCounter);
    }

    protected override void Cleanup()
    {
      base.Cleanup();
      gameScoreDisplayer.Cleanup();
      cellScoreDisplayer.Cleanup();
    }
  }
}