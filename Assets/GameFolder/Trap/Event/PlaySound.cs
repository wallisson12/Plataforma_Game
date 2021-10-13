using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip clip;

    public void PlaySoundd()
    {
        audioSource.PlayOneShot(clip,0.3f);
    }
}
