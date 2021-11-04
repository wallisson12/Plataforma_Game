using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeeperBar : MonoBehaviour
{
    public Transform keeperBar;

    void Start()
    {
                                             
    }                                                                                                          

    
    void Update()
    {
        if (GetComponent<Character>().life >= 0)
        {
            if (GetComponent<Character>().life <= 0)
            {
                GetComponent<Character>().life = 0;
            }

            keeperBar.localScale = new Vector3((GetComponent<Character>().life * 8f)/ 5,1,1);
        }
    }


}
