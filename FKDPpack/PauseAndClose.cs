using UnityEngine;
using System.Collections;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class PauseAndClose : MonoBehaviour
{
    public GameObject pauseGO;
    float tempMasterVolume;
    public bool isMuted = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Quit();
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            Pause();
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            isMuted = !isMuted;
            if (isMuted)
            {
                tempMasterVolume = _GameOptions.MasterVolume;
                _GameOptions.MasterVolume = 0;
            }
            else
            {
                _GameOptions.MasterVolume = tempMasterVolume;
            }
        }
    }

    public void Pause()
    {
        //canvas.enabled = !canvas.enabled;
        if (pauseGO)
        {
            pauseGO.SetActive(!pauseGO.activeSelf);
        }
        Time.timeScale = Time.timeScale == 0 ? 1 : 0;
    }

    public void Quit()
    {
        #if UNITY_EDITOR
            EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
