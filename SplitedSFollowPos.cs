using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplitedSFollowPos : MonoBehaviour {
    public Transform target;
    [Header("Enable to follow axis")]
    public bool x = true;
    public bool y = true;
    public bool z = true;
    Vector3 originalPos;

    private void Start()
    {
        originalPos = transform.position;
    }    
    

	void LateUpdate() {
        Vector3 finalPos = transform.position;
        Vector3 targetPos = target.position;
        if (x)
        {
            finalPos.x = originalPos.x + targetPos.x;
        }
        if (y)
        {
            finalPos.y = originalPos.y + targetPos.y;
        }
        if (z)
        {
            finalPos.z = originalPos.z + targetPos.z;
        }
        transform.position = finalPos;	
	}
}
