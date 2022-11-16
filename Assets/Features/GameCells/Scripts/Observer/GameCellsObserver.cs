using System.Collections.Generic;
using Features.GameCells.Scripts.Cell;
using Features.GameCells.Scripts.Spawn.Spawner;
using UniRx;

namespace Features.GameCells.Scripts.Observer
{
  public class GameCellsObserver
  {
    private readonly GameCellSpawner spawner;

    private readonly Dictionary<string, GameCell> cells;
    private readonly CompositeDisposable disposable;

    public readonly ReactiveCollection<GameCell> PickedCells;

    public GameCellsObserver(GameCellSpawner spawner)
    {
      this.spawner = spawner;
      cells = new Dictionary<string, GameCell>(16);
      PickedCells = new ReactiveCollection<GameCell>(new List<GameCell>(5));
      disposable = new CompositeDisposable();
    }

    public void Cleanup()
    {
      disposable.Clear();
    }

    public void SpawnCells(int count)
    {
      GameCell cell;
      for (int i = 0; i < count; i++)
      {
        cell = spawner.Spawn();
        cell.Clicked.Subscribe(OnClickCell).AddTo(disposable);
        cells.Add(cell.ID, cell);
      }
    }

    public void LockAllCells()
    {
      foreach (KeyValuePair<string,GameCell> cell in cells)
      {
        cell.Value.Lock();
      }
    }

    public void UnlockAllCells()
    {
      foreach (KeyValuePair<string,GameCell> cell in cells)
      {
        cell.Value.Unlock();
      }
    }

    public void DisableClickedCells()
    {
      
    }

    public void RespawnClickedCells()
    {
      
    }

    public void RefreshAllCellsValue()
    {
      
    }

    private void OnClickCell(CellClickContainer clickContainer)
    {
      if (clickContainer.IsOn)
        PickedCells.Add(clickContainer.Cell);
      else
        PickedCells.Remove(clickContainer.Cell);
    }
  }
}