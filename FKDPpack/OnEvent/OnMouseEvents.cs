using UnityEngine;
using UnityEngine.Events;

public class OnMouseEvents : MonoBehaviour
{
    [HideInInspector]
    public bool isMouseOver = false;
    [HideInInspector]
    public bool selected = false;
    public UnityEvent clickOnObjectUnselected;
    public UnityEvent clickOnObjectSelected;
    public UnityEvent unselected;
    public UnityEvent mouseOverObject;
    public UnityEvent mouseEnterObject;
    public UnityEvent mouseExitObject;

    void Update()
    {
        if (isMouseOver)
        {
            mouseOverObject.Invoke();
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                if (selected)
                {
                    clickOnObjectSelected.Invoke();
                }
                else
                {
                    clickOnObjectUnselected.Invoke();
                }
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                selected = false;
                unselected.Invoke();
            }
        }
    }

    void OnMouseEnter()
    {
        mouseEnterObject.Invoke();
        isMouseOver = true;
    }

    void OnMouseExit()
    {
        mouseExitObject.Invoke();
        isMouseOver = false;
    }
}

