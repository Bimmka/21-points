using UnityEngine;

namespace Features.GameCells.Data
{
  [CreateAssetMenu(fileName = "GameCellSpawnSettings", menuName = "StaticData/Game/Create Game Cell Spawn Settings", order = 52)]
  public class GameCellSpawnSettings : ScriptableObject
  {
    public Vector2Int ValueRange;
  }
}