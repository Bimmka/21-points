using System.Collections.Generic;
using Features.GameCells.Data;
using Features.GameCells.Scripts.Cell;
using Features.GameCells.Scripts.Panel;
using Features.GameCells.Scripts.Spawn.Factory;
using UniRx;
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

    public void RefreshValue(ReactiveCollection<GameCell> pickedCells)
    {
      for (int i = 0; i < pickedCells.Count; i++)
      {
        pickedCells[i].SetValue(RandomValue());
      }  
    }

    public void RefreshValue(Dictionary<string,GameCell>.ValueCollection cellsValues)
    {
      foreach (GameCell gameCell in cellsValues)
      {
        gameCell.SetValue(RandomValue());
      }
    }

    private int RandomValue() => 
      Random.Range(settings.ValueRange.x, settings.ValueRange.y);
  }
}