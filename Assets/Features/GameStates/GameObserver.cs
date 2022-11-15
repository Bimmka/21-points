using UnityEngine;
using Zenject;

namespace Features.GameStates
{
  public class GameObserver : MonoBehaviour
  {
    private Game game;

    [Inject]
    public void Construct(Game game)
    {
      this.game = game;
    }

    public void StartGame() => 
      game.StartGame();
  }
}