using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Outdated, not always work
/// </summary>
public class DeactivateOnInvisible : MonoBehaviour {
    [Range(0,512), Tooltip("How many seconds it should wait before deactivate itself")]
    public float delay = 0;
    bool isDelayActive = false;
    bool isVisible = true;

    private void Awake()
    {
        if (delay > 0)
        {
            isDelayActive = true;
        }
    }

    private void OnBecameInvisible()
    {
        if (isDelayActive)
        {
            isVisible = false;
            StopAllCoroutines();
            StartCoroutine("CheckVisibility");
        }
        else
        gameObject.SetActive(false);

    }

    private void OnBecameVisible()
    {
        if (isDelayActive)
        {
            StopAllCoroutines();
            isVisible = true;
        }
    }

    IEnumerator CheckVisibility()
    {
        yield return new WaitForSeconds(delay);
        if (!isVisible)
        {
            gameObject.SetActive(false);
        }
    }
}
