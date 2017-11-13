using UnityEngine;

public sealed class BasicController : MonoBehaviour
{
    public Rigidbody rB;
    public MovementMotor mm;
    public float jumpForce = 10;
    public float speed = 5;
    float h, v;
    private void Awake()
    {
        mm.speedModifiers += DeltaMovement;
    }

    private void Update()
    {
        h = Input.GetAxis("Horizontal")*speed;
        v = Input.GetAxis("Vertical") * speed;
        if (Input.GetButtonDown("Fire1"))
        rB.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
    }

    void DeltaMovement()
    {
        mm.finalMovement += new Vector3(h,0,v);
    }
}
