using UnityEngine;
using System.Collections;

public class SoundGODestroyer : MonoBehaviour {
    public AudioSource aS;

    void Awake()
    {
        InvokeRepeating("CheckAudio", 1, 1);
    }

    void CheckAudio()
    {
        if (!aS.isPlaying)
        {
            Destroy(gameObject);
        }
    }
}
