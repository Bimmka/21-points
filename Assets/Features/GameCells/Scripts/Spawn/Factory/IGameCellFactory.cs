using Features.GameCells.Scripts.Cell;
using UnityEngine;
using Zenject;

namespace Features.GameCells.Scripts.Spawn.Factory
{
  public interface IGameCellFactory : IFactory<Transform, int, GameCell, GameCell>
  {
    
  }
}