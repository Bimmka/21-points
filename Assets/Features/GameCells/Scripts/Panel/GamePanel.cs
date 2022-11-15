using Features.GameCells.Data;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Features.GameCells.Scripts.Panel
{
  public class GamePanel : MonoBehaviour
  {
    [field:SerializeField] public GridLayoutGroup Grid { get; private set; }
    
    [Inject]
    public void Construct(GamePanelSettings settings)
    {
      Grid.cellSize = settings.CellSize;
      Grid.spacing = settings.Spacing;
      Grid.constraint = settings.Constraint;
      Grid.constraintCount = settings.ConstraintCount;
      Grid.padding.top = (int) settings.Padding.x;
      Grid.padding.right = (int) settings.Padding.y;
      Grid.padding.bottom = (int) settings.Padding.z;
      Grid.padding.left = (int) settings.Padding.w;
    }
  }
}