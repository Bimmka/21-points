using System;
using Features.GameCells.Scripts.Cell;
using Features.Services.Assets;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace Features.GameCells.Scripts.Spawn.Factory
{
  public class GameCellFactory : PlaceholderFactory<GameCell>, IGameCellFactory
  {
    private readonly IAssetProvider assetProvider;

    public GameCellFactory(IAssetProvider assetProvider)
    {
      this.assetProvider = assetProvider;
    }
    
    public GameCell Create(Transform parent, int value, GameCell gameCell)
    {
      GameCell cell = assetProvider.Instantiate(gameCell, parent);
      Guid guid = Guid.NewGuid();
      cell.Initialize(guid.ToString(), value);
      return cell;
    }
  }
}