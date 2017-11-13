using UnityEngine;
using System.Collections;

public class CreateOption : MonoBehaviour {
    public Transform newGameObject;

    public void InstantiateNewGObyRoot()
    {
        Instantiate(newGameObject);
    }
}
