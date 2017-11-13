using UnityEngine;
using UnityEngine.Events;

public class OnInput : MonoBehaviour
{
    public KeyCode keyCode;
    public UnityEvent onKeyDown;
    public UnityEvent onKeyHold;
    public UnityEvent onKeyUp;

    void Update()
    {
        if (Input.GetKeyDown(keyCode))
        {
            onKeyDown.Invoke();
        }
        if (Input.GetKey(keyCode))
        {
            onKeyHold.Invoke();
        }
        if(Input.GetKeyUp(keyCode)){
            onKeyUp.Invoke();
        }
    }
}
