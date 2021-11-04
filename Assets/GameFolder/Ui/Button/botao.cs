using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class botao : MonoBehaviour
{
    public AudioSource audio1;

    public void TocaAudio(AudioClip som)
    {
        audio1.clip = som;
        audio1.Play();
    }
}
