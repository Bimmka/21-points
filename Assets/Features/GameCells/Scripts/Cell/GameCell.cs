using System;
using UnityEngine;
using UnityEngine.UI;

namespace Features.GameCells.Scripts.Cell
{
  public class GameCell : MonoBehaviour
  {
    [SerializeField] private Button button;
    
    public string ID { get; private set; }
    public int Value { get; private set; }

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

    private void Click()
    {
      
    }
  }
}