using UnityEngine;

namespace Features.Level.Data
{
  [CreateAssetMenu(fileName = "LevelSettings", menuName = "StaticData/Level/Create Level Settings", order = 52)]
  public class LevelSettings : ScriptableObject
  {
    public int CellsForSpawn = 16;
  }
}