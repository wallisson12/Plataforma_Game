using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    Transform boss;
    public AudioClip sound;

    void OnTriggerEnter2D(Collider2D outro)
    {
        if (outro.CompareTag("Enemy"))
        {
            outro.GetComponent<BossBrainController>().enabled = false;
            boss = outro.transform;
            outro.transform.parent = transform;
            outro.transform.localPosition = Vector3.zero;
        }
    }

    public void SoundSpike()
    {

        GetComponent<AudioSource>().PlayOneShot(sound, 0.8f);

    }

    public void ReleaseBoss()
    {
        if (boss != null)
        {
            boss.GetComponent<BossBrainController>().enabled = true;
            boss.parent = null;
        }
    }
}
