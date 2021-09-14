using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public int life;
    public Transform skin;
    void Start()
    {
        
    }

    
    void Update()
    {
        if (life <= 0)
        {
            skin.GetComponent<Animator>().Play("Die",-1);
        }
    }
}
