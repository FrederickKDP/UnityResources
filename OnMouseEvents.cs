using UnityEngine;
using UnityEngine.Events;

public class OnMouseEvents : MonoBehaviour
{
    bool isMouseOver = false;
    public UnityEvent clickOnObject;
    public UnityEvent mouseOverObject;
    public UnityEvent mouseExitObject;

    void Update()
    {
        if (isMouseOver)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                clickOnObject.Invoke();
            }
        }
    }

    void OnMouseEnter()
    {
        mouseOverObject.Invoke();
        isMouseOver = true;
    }

    void OnMouseExit()
    {
        mouseExitObject.Invoke();
        isMouseOver = false;
    }
}

