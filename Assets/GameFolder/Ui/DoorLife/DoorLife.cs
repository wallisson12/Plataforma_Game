using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLife : MonoBehaviour
{
    public Transform doorLife;
    private Vector3 healthBarScale;
    float healthPercent;

    [SerializeField]
    int changLife;
    
    void Start()
    {
        changLife = GetComponent<Character>().life;
        healthBarScale = doorLife.localScale;
        healthPercent = healthBarScale.x / GetComponent<Character>().life;
    }

   
    void Update()
    {
        if (changLife != GetComponent<Character>().life)
        {
            changLife = GetComponent<Character>().life;
            GetComponent<Character>().skin.GetComponent<Animator>().Play("Die",-1);
        }

        if (GetComponent<Character>().life <=0)
        {
            GetComponent<Character>().life = 0;
            this.enabled = false;
            Destroy(gameObject,1f);
        }

        if (GetComponent<Character>().life >= 0)
        {
            if (GetComponent<Character>().life == 0)
            {
                GetComponent<Character>().life = 0;
            }

            UpdateLife();
        }
        


    }

    void UpdateLife()
    {
        healthBarScale.x = healthPercent * GetComponent<Character>().life;
        doorLife.localScale = healthBarScale;

    }


}
