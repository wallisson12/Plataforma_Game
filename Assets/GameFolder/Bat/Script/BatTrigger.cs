using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatTrigger : MonoBehaviour
{

    public Transform [] bat;

    private void OnTriggerEnter2D(Collider2D outro)
    {
        if (outro.CompareTag("Player"))
        {
            foreach (Transform obj in bat)
            {
                obj.GetComponent<BatController>().enabled = true;
                obj.GetComponent<BatController>().player = outro.transform;
            }
        }
    }

    //Destroi o trigger que ativa os bats
    private void OnTriggerExit2D(Collider2D outro)
    {
        if (outro.CompareTag("Player"))
        {
            Destroy(gameObject);
        }

    }
}
