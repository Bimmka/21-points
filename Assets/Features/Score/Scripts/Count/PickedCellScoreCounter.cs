using UniRx;

namespace Features.Score.Scripts.Count
{
  public class PickedCellScoreCounter : IScoreCounter
  {
    public IntReactiveProperty Score { get; private set; }

    public PickedCellScoreCounter()
    {
      Score = new IntReactiveProperty(0);
    }
    
    public void AddScore(int count) => 
      Score.Value += count;

    public void DecreaseScore(int count) => 
      Score.Value -= count;

    public void ResetScore()
    {
      Score.Value = 0;
    }
  }
}