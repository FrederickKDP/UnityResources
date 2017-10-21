using UnityEngine;
using System.Collections;

public class ChangeAudio : MonoBehaviour {
	public void ToogleAudio (AudioSource aS) {
        if (aS.isPlaying)
        {
            aS.Stop();
        }
        else
        {
            aS.Play();           
        }
	}
}
