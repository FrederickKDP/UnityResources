using UnityEngine;
using UnityEngine.UI;

public class StatBarLinkedInt : MonoBehaviour
{
    public Slider slider;
    public Text text;
    public Image image;

    public GameActor targetScriptExInt;

    public string exIntName = "";
    bool enableChange = true;
    ExInt tempExInt;

    public void ChangedStat()
    {
        UpdateText();
        HideWhenZero();
    }

    void Awake()
    {
        tempExInt = ((ExInt)targetScriptExInt.GetType().GetField(exIntName).GetValue(targetScriptExInt));
        UpdateText();
    }

    void UpdateText()
    {
        if (enableChange)
        {
            ((ExInt)targetScriptExInt.GetType().GetField(exIntName).GetValue(targetScriptExInt)).varValue = Mathf.RoundToInt(tempExInt.baseValue * slider.value);
            text.text = "" + tempExInt.varValue;
        }
    }

    private void OnValidate()
    {
        try
        {
            enableChange = true;
            tempExInt = ((ExInt)targetScriptExInt.GetType().GetField(exIntName).GetValue(targetScriptExInt));
        }
        catch
        {
            enableChange = false;
            Debug.LogWarning("Var not found");
        }
    }

    void HideWhenZero()
    {
        if (slider.value <= 0)
        {
            image.color = new Color(1, 1, 1, 0);
        }
        else
        {
            image.color = new Color(1, 1, 1, 1);
        }
    }
}
