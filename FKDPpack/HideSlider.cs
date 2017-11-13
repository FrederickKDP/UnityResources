using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public sealed class HideSlider : MonoBehaviour
{
    public Slider slider;
    public Image image;
    public void HideWhenZero()
    {
        if (slider.value <= 0) {
            image.color = new Color(1, 1, 1, 0);
        }
        else
        {
            image.color = new Color(1, 1, 1, 1);
        }
    }
}
