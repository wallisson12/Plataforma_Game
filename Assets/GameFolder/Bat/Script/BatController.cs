using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatController : MonoBehaviour
{

    public Transform player;
    public float attackTime;
  
    void Update()
    {
        if (GetComponent<Character>().life <= 0)
        {
            GetComponent<AudioSource>().enabled = false;
            GetComponent<CircleCollider2D>().enabled = false;
            GetComponent<Rigidbody2D>().gravityScale = 1f;
            Destroy(gameObject, 3f);
            this.enabled = false;
        }


        if (Vector2.Distance(transform.position,player.GetComponent<CapsuleCollider2D>().bounds.center) > 0.4f)
        {
            attackTime = 0;
            transform.position = Vector2.MoveTowards(transform.position, player.GetComponent<CapsuleCollider2D>().bounds.center, 2f * Time.deltaTime);
        }
        else
        {
            attackTime = attackTime + Time.deltaTime;

            if (attackTime >= 0.5f && player.GetComponent<Character>().life != 0)
            {
                attackTime = 0;
                player.GetComponent<Character>().PlayerDamage(1);
            }
        }
    }
}
