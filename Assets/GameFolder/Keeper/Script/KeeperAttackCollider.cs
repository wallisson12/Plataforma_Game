using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeeperAttackCollider : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D outro)
    {
        if (outro.CompareTag("Player"))
        {
            outro.GetComponent<Character>().PlayerDamage(10);
        }
    }
}
