using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FloorCollider : MonoBehaviour
{
    AudioSource aud;
    public AudioClip son;

    void Start()
    {
        aud = GetComponent<AudioSource>();   
    }

    private void OnTriggerEnter2D(Collider2D outro)
    {
        if (outro.CompareTag("Ground"))
        {
            aud.PlayOneShot(son,0.5f);
        }
    }
}
