using UnityEngine;
using System.Collections;

public class ChangeObjects : MonoBehaviour {
    public void ToogleGameObject(GameObject gO)
    {
        if (gO.activeSelf)
        {
            gO.SetActive(false);
        }
        else
        {
            gO.SetActive(true);
        }
    }
}
