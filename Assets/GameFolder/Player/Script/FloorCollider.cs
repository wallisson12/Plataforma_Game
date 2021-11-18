using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FloorCollider : MonoBehaviour
{
    AudioSource aud;
    public AudioClip son;
    public Rigidbody2D player;


    void Start()
    {
        aud = GetComponent<AudioSource>();   
    }

    void OnTriggerEnter2D(Collider2D outro)
    {
        if (outro.CompareTag("Ground"))
        {
            aud.PlayOneShot(son,0.5f);
            player.bodyType = RigidbodyType2D.Dynamic;
        }

        if (outro.gameObject.name.Equals("Plataforma"))
        {
            player.bodyType = RigidbodyType2D.Dynamic;
            player.transform.parent = outro.transform;
        }

    }

    void OnTriggerStay2D(Collider2D outro)
    {
        if (outro.gameObject.name.Equals("Plataforma1"))
        {
            player.bodyType = RigidbodyType2D.Kinematic;
            player.transform.parent = outro.transform;
            player.velocity = new Vector3(0,0,0);
        }

    }

    private void OnTriggerExit2D(Collider2D outro)
    {
        if (outro.gameObject.name.Equals("Plataforma") ||
            outro.gameObject.name.Equals("Plataforma1"))
        {
            player.transform.parent = null;
        }
    }
}
