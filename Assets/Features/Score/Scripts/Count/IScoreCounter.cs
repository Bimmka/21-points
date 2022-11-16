using UniRx;

namespace Features.Score.Scripts.Count
{
  public interface IScoreCounter
  {
    IntReactiveProperty Score { get; }
    void AddScore(int count);
    void DecreaseScore(int count);
    void ResetScore();
  }
}