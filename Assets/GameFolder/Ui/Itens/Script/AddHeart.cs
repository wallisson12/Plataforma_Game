﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddHeart : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D outro)
    {
        if (outro.CompareTag("Player"))
        {
            if (outro.GetComponent<Character>().life < 100)
            {
                outro.GetComponent<PlayerController>().audioSource.PlayOneShot(outro.GetComponent<PlayerController>().heartSound,0.3f);
                outro.GetComponent<Character>().AddHeart(5);
                Destroy(gameObject);

            }
        }
    }
}
