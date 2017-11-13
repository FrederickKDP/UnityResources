using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public MovementMotor mm;
    public float speed;

    private void Awake()
    {
        mm.speedModifiers += MoveGOForward;
    }

    void MoveGOForward()
    {
        print("moving!");
        mm.finalMovement += new Vector3(speed,0,0);
    }
}
