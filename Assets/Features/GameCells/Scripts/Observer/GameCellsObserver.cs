using System;
using System.Collections;
using System.Collections.Generic;
using Features.GameCells.Scripts.Cell;
using Features.GameCells.Scripts.Spawn.Spawner;
using Features.Services.Cleanup;
using Features.Services.Coroutine;
using UniRx;

namespace Features.GameCells.Scripts.Observer
{
  public class GameCellsObserver : ICleanup
  {
    private readonly GameCellSpawner spawner;
    private readonly ICoroutineRunner coroutineRunner;

    private readonly Dictionary<string, GameCell> cells;
    private readonly CompositeDisposable disposable;

    public readonly ReactiveCollection<GameCell> PickedCells;

    public GameCellsObserver(GameCellSpawner spawner, ICleanupService cleanupService, ICoroutineRunner coroutineRunner)
    {
      this.spawner = spawner;
      this.coroutineRunner = coroutineRunner;
      cells = new Dictionary<string, GameCell>(16);
      PickedCells = new ReactiveCollection<GameCell>(new List<GameCell>(5));
      disposable = new CompositeDisposable();
      
      cleanupService.Register(this);
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

    public void DisableClickedCells(Action callback = null) => 
      coroutineRunner.StartCoroutine(DisableCells(callback));

    public void RespawnClickedCells(Action callback = null) => 
      coroutineRunner.StartCoroutine(EnableCells(callback));

    public void RefreshAllCellsValue() => 
      spawner.RefreshValue(cells.Values);

    public void ResetClickedCells() => 
      PickedCells.Clear();

    private void OnClickCell(CellClickContainer clickContainer)
    {
      if (clickContainer.IsOn)
        PickedCells.Add(clickContainer.Cell);
      else
        PickedCells.Remove(clickContainer.Cell);
    }

    private IEnumerator DisableCells(Action callback = null)
    {
      for (int i = 0; i < PickedCells.Count; i++)
      {
        PickedCells[i].Disable();
      }
      
      while (IsHaveAnimatedPickedCells())
      {
        yield return null;
      }
      
      callback?.Invoke();
    }
    
    private IEnumerator EnableCells(Action callback = null)
    {
      spawner.RefreshValue(PickedCells);
      
      for (int i = 0; i < PickedCells.Count; i++)
      {
        PickedCells[i].Enable();
      }

      while (IsHaveAnimatedPickedCells())
      {
        yield return null;
      }
      callback?.Invoke();
    }

    private bool IsHaveAnimatedPickedCells()
    {
      for (int i = 0; i < PickedCells.Count; i++)
      {
        if (PickedCells[i].IsAnimating == true)
          return true;
      }

      return false;
    }
  }
}