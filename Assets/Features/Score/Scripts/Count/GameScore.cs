using UniRx;

namespace Features.Score.Scripts.Count
{
  public class GameScore : IScoreCounter
  {
    public IntReactiveProperty Score { get; private set; }

    public GameScore()
    {
      Score = new IntReactiveProperty(0);
    }

    public void AddScore(int count) => 
      Score.SetValueAndForceNotify(Score.Value + count);

    public void DecreaseScore(int count)
    {
      if (Score.Value - count < 0)
        ResetScore();
      else
        Score.SetValueAndForceNotify(Score.Value - count);
    }

    public void ResetScore() => 
      Score.SetValueAndForceNotify(0);
    
  }
}