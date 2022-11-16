using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Features.GameCells.Scripts.Cell
{
  public class GameCell : MonoBehaviour
  {
    [SerializeField] private Button button;

    private bool isOn;
    public string ID { get; private set; }
    public int Value { get; private set; }
    
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
    }

    public void Lock()
    {
      
    }

    public void Unlock()
    {
      
    }

    private void Click()
    {
      isOn = !isOn;
      Clicked.Execute(ClickContainer(isOn));
    }

    private CellClickContainer ClickContainer(bool isOn) => 
      new CellClickContainer(this, isOn);
  }
}