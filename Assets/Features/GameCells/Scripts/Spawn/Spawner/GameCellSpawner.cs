using Features.GameCells.Scripts.Cell;
using Features.GameCells.Scripts.Panel;
using Features.GameCells.Scripts.Spawn.Factory;

namespace Features.GameCells.Scripts.Spawn.Spawner
{
  public class GameCellSpawner
  {
    private readonly GamePanel spawnParent;
    private readonly GameCell cellPrefab;
    private readonly IGameCellFactory factory;

    public GameCellSpawner(GamePanel spawnParent, GameCell cellPrefab, IGameCellFactory factory)
    {
      this.spawnParent = spawnParent;
      this.cellPrefab = cellPrefab;
      this.factory = factory;
    }

    public GameCell Spawn() => 
      factory.Create(spawnParent.transform, cellPrefab);
  }
}