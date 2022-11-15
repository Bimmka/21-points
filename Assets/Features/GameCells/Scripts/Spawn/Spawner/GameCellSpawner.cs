using Features.GameCells.Data;
using Features.GameCells.Scripts.Cell;
using Features.GameCells.Scripts.Panel;
using Features.GameCells.Scripts.Spawn.Factory;
using UnityEngine;

namespace Features.GameCells.Scripts.Spawn.Spawner
{
  public class GameCellSpawner
  {
    private readonly GamePanel gamePanel;
    private readonly GameCell cellPrefab;
    private readonly IGameCellFactory factory;
    private readonly GameCellSpawnSettings settings;

    public GameCellSpawner(GamePanel gamePanel, GameCell cellPrefab, IGameCellFactory factory, GameCellSpawnSettings settings)
    {
      this.gamePanel = gamePanel;
      this.cellPrefab = cellPrefab;
      this.factory = factory;
      this.settings = settings;
    }

    public GameCell Spawn() => 
      factory.Create(gamePanel.Grid.transform, RandomValue(), cellPrefab);

    private int RandomValue() => 
      Random.Range(settings.ValueRange.x, settings.ValueRange.y);
  }
}