using System.Collections.Generic;
using Features.GameCells.Scripts.Cell;
using Features.GameCells.Scripts.Spawn.Spawner;

namespace Features.GameCells.Scripts.Observer
{
  public class GameCellsObserver
  {
    private readonly GameCellSpawner spawner;

    private readonly Dictionary<string, GameCell> cells;

    public GameCellsObserver(GameCellSpawner spawner)
    {
      this.spawner = spawner;
      cells = new Dictionary<string, GameCell>(16);
    }

    public void SpawnCells(int count)
    {
      GameCell cell;
      for (int i = 0; i < count; i++)
      {
        cell = spawner.Spawn();
        cells.Add(cell.ID, cell);
      }
    }
  }
}