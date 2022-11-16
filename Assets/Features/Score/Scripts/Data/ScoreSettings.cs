using UnityEngine;

namespace Features.Score.Scripts.Data
{
  [CreateAssetMenu(fileName = "ScoreSettings", menuName = "StaticData/Score/Create Score Settings", order = 52)]
  public class ScoreSettings : ScriptableObject
  {
    public int MinBoundPoints = 21;
    public int PointsToWin = 60;
  }
}