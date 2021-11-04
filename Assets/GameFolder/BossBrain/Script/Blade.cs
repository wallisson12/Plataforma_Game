﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{
    public Transform A, B, C, D;
    public Vector3 targetPosition;

    void Start()
    {
        targetPosition = A.position;
    }
    void Update()
    {
        if (transform.position == A.position)
        {
            targetPosition = B.position; 
        }
        if (transform.position == B.position)
        {
            targetPosition = C.position;
        }
        if (transform.position == C.position)
        {
            targetPosition = D.position;
        }
        if (transform.position == D.position)
        {
            targetPosition = A.position;
        }

        transform.position = Vector2.MoveTowards(transform.position,targetPosition, 5 * Time.deltaTime);
        transform.Rotate(0,0,-1000 * Time.deltaTime);
        
    }

    void OnTriggerEnter2D(Collider2D outro)
    {
        if (outro.CompareTag("Player") && outro.GetComponent<Character>().life > 0)
        {
            outro.GetComponent<Character>().PlayerDamage(1);
        }
    }
}
