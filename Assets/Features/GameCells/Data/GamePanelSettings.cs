using UnityEngine;
using UnityEngine.UI;

namespace Features.GameCells.Data
{
  [CreateAssetMenu(fileName = "GamePanelSettings", menuName = "StaticData/Game/Create Game Panel Settings", order = 52)]
  public class GamePanelSettings : ScriptableObject
  {
    public GridLayoutGroup.Constraint Constraint;
    public int ConstraintCount;
    public Vector2 CellSize;
    public Vector2 Spacing;
    public Vector4 Padding;
  }
}