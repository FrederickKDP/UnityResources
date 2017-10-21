using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateOutOfView : MonoBehaviour {
    public Camera[] cams;
    [Tooltip("When enabled makes an array of existing cameras and checks with all of them, use with caution")]
    public bool checkAllCams = false;

    [Tooltip("Should it use an alternative update method for optimization or as soon as possible?")]
    public bool isSlowUpdate = true;
    [Range(0.25f, 256)]
    public float slowUpdateRate = 3f;

    bool isVisible = true;

    [Range(0, 64), Tooltip("How many seconds it should wait before deactivate itself")]
    public float delay = 2;

    private void Awake()
    {
        if (checkAllCams)
        {
            cams = Camera.allCameras;
        }
        else
        {
            cams = new Camera[1];
            cams[0] = Camera.main;
        }
        if (isSlowUpdate)
        {
            StartCoroutine("SlowUpdate");
        }
    }

    private void OnEnable()
    {
        if (isSlowUpdate)
        {
            StopAllCoroutines();
            StartCoroutine("SlowUpdate");
        }
    }

    private void OnDisable()
    {
        if (isSlowUpdate)
        {
            StopAllCoroutines();
        }
    }

    private void Update()
    {
        if (!isSlowUpdate)
        {
            CheckVisibility();
        }
    }

    bool CheckInBound(Camera cam)
    {
        Vector3 bounds = cam.WorldToViewportPoint(transform.position);
        if (bounds.x > 0 &&
            bounds.x < 1 &&
            bounds.y > 0 &&
            bounds.y < 1)
        {
            //print("Inside");
            return true;
        }
        else
        {
            //print("Outside");
            return false;
        }
    }

    IEnumerator SlowUpdate()
    {
        while (true)
        {
            yield return new WaitForSeconds(slowUpdateRate);
            CheckVisibility();
            if (!isVisible)
            {
                yield return new WaitForSeconds(delay);
                if (!isVisible)
                {
                    gameObject.SetActive(false);
                    //StopAllCoroutines();
                }
            }
        }
    }

    IEnumerator DeactivateStillInvisible()
    {
        yield return new WaitForSeconds(delay);
        if (!isVisible)
        {
            gameObject.SetActive(false);
            //StopAllCoroutines();
        }
        yield return null;
    }

    void CheckVisibility()
    {
        if (checkAllCams)
        {
            bool found = false;
            foreach (var item in cams)
            {
                if (CheckInBound(item))
                {
                    found = true;
                }
            }
            if (found)
            {
                isVisible = true;
            }
            else
            {
                isVisible = false;
            }
        }
        else
        {
            isVisible = CheckInBound(cams[0]);
        }
        if (!isVisible)
        {
            if(!isSlowUpdate)
            StartCoroutine("DeactivateStillInvisible");
        }
    }
}
