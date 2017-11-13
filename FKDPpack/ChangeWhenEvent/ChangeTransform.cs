using UnityEngine;
using System.Collections;

public class ChangeTransform : MonoBehaviour {
    public bool saveOriginalTransformValues = false;
    Vector3 originalPosition, originalRotation, originalScale;

    void Start()
    {
        if (saveOriginalTransformValues)
        {
            originalPosition = transform.position;
            originalRotation = transform.rotation.eulerAngles;
            originalScale = transform.localScale;
        }
    }

    public void ResetAllOriginal()
    {
        transform.position = originalPosition;
        transform.rotation = Quaternion.Euler(originalRotation);
        transform.localScale = originalScale;
    }

    public void ResetRotation()
    {
        transform.rotation = Quaternion.Euler(originalRotation);
    }
    public void ResetScale()
    {
        transform.localScale = originalScale;
    }
    public void ResetPosition()
    {
        transform.position = originalPosition;
    }

    public void DoSpinX(int x)
    {
        Vector3 axisSpeed = new Vector3(x,0,0);
        transform.Rotate(axisSpeed*Time.deltaTime);
    }
    public void DoSpinY(int y)
    {
        Vector3 axisSpeed = new Vector3(0, y, 0);
        transform.Rotate(axisSpeed * Time.deltaTime);
    }
    public void DoSpinZ(int z)
    {
        Vector3 axisSpeed = new Vector3(0, 0, z);
        transform.Rotate(axisSpeed * Time.deltaTime);
    }
}
