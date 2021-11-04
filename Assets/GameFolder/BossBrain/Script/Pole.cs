using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pole : MonoBehaviour
{
    public Transform spike;
    public AudioClip sound;

    void OnTriggerEnter2D(Collider2D outro)
    {
        if (outro.name.Equals("AttackCollider"))
        {
            GetComponent<AudioSource>().PlayOneShot(sound,0.5f);
            spike.GetComponent<Animator>().Play("Skipe",-1);
            GetComponent<Animator>().Play("Pole",-1);
        }
    }
}
