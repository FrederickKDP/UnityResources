using UnityEngine;

public class MovementMotor : MonoBehaviour
{
    [HideInInspector]
    public Vector3 finalMovement = Vector3.zero;
    public delegate void SpeedModifiers();
    public event SpeedModifiers speedModifiers;

    void FixedUpdate()
    {
        if(speedModifiers!=null)
            speedModifiers();
        transform.position += finalMovement*Time.fixedDeltaTime;
        finalMovement = Vector3.zero;
    }

    public void UnsubscribleAll()
    {
        speedModifiers = null;
    }
}
