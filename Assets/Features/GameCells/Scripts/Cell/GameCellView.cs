using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Features.GameCells.Scripts.Cell
{
  public class GameCellView : MonoBehaviour
  {
    [SerializeField] private TextMeshProUGUI valueText;
    [SerializeField] private Image viewImage;
    [SerializeField] private Color clickedColor;
    [SerializeField] private Color releasedColor;
    [SerializeField] private float animationTime;
    public bool IsAnimating { get; private set; }

    public void DisplayValue(int value) => 
      valueText.text = value.ToString();

    public void DisplayClickedView(bool isOn) => 
      viewImage.color = isOn ? clickedColor : releasedColor;
    
    public void DisplayHidenClickedView(bool isOn)
    {
      Color color = isOn ? clickedColor : releasedColor;
      color.a = 0;
      viewImage.color = color;
    }

    public void Disable()
    {
      SetIsAnimating();
      valueText.DOFade(0, animationTime).SetEase(Ease.InOutSine);
      viewImage.DOFade(0, animationTime).SetEase(Ease.InOutSine).OnComplete(ResetIsAnimating);
    }

    public void Enable()
    {
      SetIsAnimating();
      valueText.DOFade(1, animationTime).SetEase(Ease.InOutSine);
      viewImage.DOFade(1, animationTime).SetEase(Ease.InOutSine).OnComplete(ResetIsAnimating);
    }

    private void SetIsAnimating() => 
      IsAnimating = true;

    private void ResetIsAnimating() => 
      IsAnimating = false;
  }
}