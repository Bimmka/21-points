using Features.Level.Scripts;
using Features.Score.Scripts.Count;
using Features.UI.Windows.Base;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Features.UI.Windows.GameFinish.Scripts
{
  public class UIGameFinishWindow : BaseWindow
  {
    [SerializeField] private Button restartButton;
    [SerializeField] private TextMeshProUGUI gameScoreText;
    [SerializeField] private string gameScoreTextFormat;
    
    private LevelFlow levelFlow;
    private int gameScore;

    [Inject]
    public void Construct(LevelFlow levelFlow, GameScore gameScore)
    {
      this.gameScore = gameScore.Score.Value;
      this.levelFlow = levelFlow;
    }

    public override void Open()
    {
      gameScoreText.text = string.Format(gameScoreTextFormat, gameScore);
      base.Open();
    }

    protected override void Subscribe()
    {
      base.Subscribe();
      restartButton.onClick.AddListener(RestartGame);
    }

    protected override void Cleanup()
    {
      base.Cleanup();
      restartButton.onClick.RemoveListener(RestartGame);
    }

    private void RestartGame()
    {
      levelFlow.Restart();
      Destroy();
    }
  }
}