using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeeperEvent : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip attack;

   
    public void KeeperSound()
    {
        audioSource.PlayOneShot(attack,0.3f);
    }
}
