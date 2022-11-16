using DG.Tweening;
using Features.Score.Scripts.Count;
using TMPro;
using UniRx;
using UnityEngine;

namespace Features.UI.Windows.HUD.Scripts
{
  public class ScoreDisplayer : MonoBehaviour
  {
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private string scoreTextFormat;
    [SerializeField] private float scoreChangeDuration;

    private Tweener scoreTween;
    private int currentScore;
    
    private readonly CompositeDisposable disposable = new CompositeDisposable();
    
    public void Construct(IScoreCounter scoreCounter) => 
      scoreCounter.Score.Subscribe(OnChangeScore).AddTo(disposable);

    public void Cleanup() => 
      disposable.Clear();

    private void OnChangeScore(int score)
    {
      if (scoreTween != null && scoreTween.IsPlaying())
        scoreTween.Kill();
      
      if (score == currentScore)
        SetScore(score);
      else
        scoreTween = DOTween.To(CurrentScore, SetScore, score, scoreChangeDuration).SetEase(Ease.InOutSine).OnComplete(ResetTweener);
    }

    private void Display(int score) => 
      scoreText.text = string.Format(scoreTextFormat, score);

    private int CurrentScore() => 
      currentScore;

    private void SetScore(int score)
    {
      currentScore = score;
      Display(currentScore);
    }

    private void ResetTweener() => 
      scoreTween = null;
  }
}