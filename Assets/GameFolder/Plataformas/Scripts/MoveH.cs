using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveH : MonoBehaviour
{
    [Header("Pontos")]
    public Transform A, B;

    [Header("Speed")]
    [SerializeField]
    float speed = 3f;

    [Header("Lado")]
    public bool isRight;

    void Update()
    {
        if (isRight)
        {
            if (Vector2.Distance(transform.position,A.position) < 0.2f)
            {
                isRight = false;
            }

            transform.position = Vector2.MoveTowards(transform.position, A.position, speed * Time.deltaTime);

        }
        else
        {
            if (Vector2.Distance(transform.position, B.position) < 0.2f)
            {
                isRight = true;
            }

            transform.position = Vector2.MoveTowards(transform.position,B.position,speed*Time.deltaTime);

        }            
    }
}
