using UnityEngine;
using System.Collections;

public class ParticleGODestroyer : MonoBehaviour {
    public ParticleSystem pS;

    void Awake()
    {
        InvokeRepeating("CheckParticleEmitter", 1, 1);
    }

    void CheckParticleEmitter()
    {
        if (!pS.isPlaying)
        {
            Destroy(gameObject);
        }
    }
}
