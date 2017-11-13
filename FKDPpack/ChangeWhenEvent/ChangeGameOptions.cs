using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// To be used in conjuction with _GameOptions and a Slider
/// </summary>
public sealed class ChangeGameOptions : MonoBehaviour
{
    public Slider slider;
    public void UpdateMasterVolume()
    {
        _GameOptions.MasterVolume = slider.value;
    }
    public void UpdateBGMvolume()
    {
        _GameOptions.BGMvolume = slider.value;
    }
    public void UpdateSFXvolume()
    {
        _GameOptions.SFXvolume = slider.value;
    }
    public void UpdateVoiceVolume()
    {
        _GameOptions.VoiceVolume = slider.value;
    }

    private void Reset()
    {
        if (GetComponent<Slider>())
        {
            slider = GetComponent<Slider>();
        }
    }
}
