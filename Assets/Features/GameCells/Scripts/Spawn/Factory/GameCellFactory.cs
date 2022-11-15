using Features.GameCells.Scripts.Cell;
using UnityEngine;
using Zenject;

namespace Features.GameCells.Scripts.Spawn.Factory
{
  public class GameCellFactory : PlaceholderFactory<GameCell>, IGameCellFactory
  {
    public GameCell Create(Transform param1, GameCell param2)
    {
      return null;
    }
  }
}