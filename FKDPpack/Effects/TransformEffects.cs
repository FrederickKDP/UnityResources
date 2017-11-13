using UnityEngine;

public sealed class TransformEffects : MonoBehaviour
{
    public MovementMotor movimentMotor;

    public bool randomStart = false;
    [Range(1, 50)]
    public float randomSpread = 1;
    /// <summary>
    /// 0 - X
    /// 1 - Y
    /// 2 - Z
    /// </summary>
    public bool[] activateFX = new bool[3];
    [Range(0.01f,10)]
    public float range = 1;
    [Range(0.1f, 10)]
    public float speed = 1;
    Vector3 startPos;
    float randomValue = 0;

    public void SetTypeAndActivate(int type)
    {
        activateFX[type] = true;
    }

    void Start()
    {
        startPos = transform.position;
        if (randomStart)
        {
            randomValue = Random.value;
        }
    }

    public void BounceLike()
    {

    }

    private void Update()
    {
        Vector3 deltaPos = Vector3.zero;
        if (activateFX[0])
        {
            deltaPos += new Vector3(Mathf.Sin(randomValue * randomSpread + (Time.time * speed)) * range, 0, 0);            
        }
        if (activateFX[1])
        {
            deltaPos += new Vector3(0, Mathf.Sin(randomValue * randomSpread + (Time.time * speed)) * range, 0);
        }
        if (activateFX[2])
        {
            deltaPos += new Vector3(0, 0, Mathf.Sin(randomValue * randomSpread + (Time.time * speed)) * range);
        }

        transform.position = startPos + deltaPos;
    }
}
