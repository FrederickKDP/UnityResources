using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public sealed class StatBarPerCent : MonoBehaviour
{
    public Slider slider;
    public Text text;
    public Image image;

    public void ChangedStat()
    {
        UpdateText();
        HideWhenZero();
    }

    void UpdateText()
    {
       text.text = "" + Mathf.RoundToInt(slider.value * 100) + "%";
    }

    void HideWhenZero()
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
