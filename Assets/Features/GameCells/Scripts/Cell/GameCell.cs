using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Features.GameCells.Scripts.Cell
{
  [RequireComponent(typeof(GameCellView))]
  public class GameCell : MonoBehaviour
  {
    [SerializeField] private GameCellView view;
    [SerializeField] private Button button;

    private bool isOn;
    public string ID { get; private set; }
    public int Value { get; private set; }

    public bool IsAnimating => view.IsAnimating;
    
    public readonly ReactiveCommand<CellClickContainer> Clicked = new ReactiveCommand<CellClickContainer>();

    private void Awake()
    {
      button.onClick.AddListener(Click);
    }

    private void OnDestroy()
    {
      button.onClick.RemoveListener(Click);
    }

    public void Initialize(string id, int value)
    {
      ID = id;
      SetValue(value);
    }

    public void SetValue(int value)
    {
      Value = value;
      view.DisplayValue(value);
    }

    public void Disable()
    {
      isOn = false;
      view.Disable();
    }

    public void Enable()
    {
      view.DisplayHidenClickedView(isOn);
      view.Enable();
    }

    public void Lock() => 
      button.enabled = false;

    public void Unlock() => 
      button.enabled = true;

    private void Click()
    {
      isOn = !isOn;
      view.DisplayClickedView(isOn);
      Clicked.Execute(ClickContainer(isOn));
    }

    private CellClickContainer ClickContainer(bool isOn) => 
      new CellClickContainer(this, isOn);
  }
}