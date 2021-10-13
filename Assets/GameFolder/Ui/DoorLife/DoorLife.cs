using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLife : MonoBehaviour
{
    public Transform doorLife;

    [SerializeField]
    int changLife;
    // Start is called before the first frame update
    void Start()
    {
        changLife = GetComponent<Character>().life;
    }

    // Update is called once per frame
    void Update()
    {
        if (changLife != GetComponent<Character>().life)
        {
            changLife = GetComponent<Character>().life;
            GetComponent<Character>().skin.GetComponent<Animator>().Play("Die",-1);
        }

        if (GetComponent<Character>().life <=0)
        {
            this.enabled = false;
            Destroy(gameObject,1f);
        }

        doorLife.localScale = new Vector3(((float)1 * GetComponent<Character>().life)/10, 1, 1);

    }


}
