using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnyInputToEnable : MonoBehaviour {
    public Transform target;
    [Tooltip("If enabled, destroy this component after pressing any button")]
    public bool destroyThis;

	void Update () {
        if (Input.anyKeyDown)
        {
            target.gameObject.SetActive(true);
            gameObject.SetActive(false);
            if(destroyThis)
            Destroy(this);
        }
    }
}
