using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCollider : MonoBehaviour
{
    public Transform player;
   
    private void OnTriggerEnter2D(Collider2D outro)
    {
        if (outro.CompareTag("Enemy"))
        {
            if(player.GetComponent<PlayerController>().comboNum == 1)
            {
                outro.GetComponent<Character>().life--;
            }

            if (player.GetComponent<PlayerController>().comboNum == 2)
            {
                outro.GetComponent<Character>().life -= 2;
            }
        }
    }
}
