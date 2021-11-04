using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLife_2 : MonoBehaviour
{
    public Transform lifeBar2;
    private int ChangeLife2;

    void Start()
    {
        ChangeLife2 = GetComponent<Character>().life;        
    }

    void Update()
    {
        if (ChangeLife2 != GetComponent<Character>().life)
        {
            ChangeLife2 = GetComponent<Character>().life;
        }

        if (GetComponent<Character>().life <= 0)
        {
            this.enabled = false;
            GetComponent<BoxCollider2D>().enabled = false;
            Destroy(gameObject,0.5f);
        }

        lifeBar2.localScale = new Vector3((float)1 * GetComponent<Character>().life/10,1,1);
    }
}
