namespace Features.GameCells.Scripts.Cell
{
  public struct CellClickContainer
  {
    public GameCell Cell;
    public bool IsOn;

    public CellClickContainer(GameCell cell, bool isOn)
    {
      Cell = cell;
      IsOn = isOn;
    }
  }
}