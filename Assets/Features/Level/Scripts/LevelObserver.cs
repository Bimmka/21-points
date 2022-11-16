using UnityEngine;
using Zenject;

namespace Features.Level.Scripts
{
  public class LevelObserver : MonoBehaviour
  {
    private LevelFlow levelFlow;

    [Inject]
    public void Construct(LevelFlow levelFlow)
    {
      this.levelFlow = levelFlow;
    }

    private void OnDestroy()
    {
      levelFlow.Cleanup();
    }

    public void StartGame()
    {
      levelFlow.PrepareLevel();
      levelFlow.Start();
    }
  }
}