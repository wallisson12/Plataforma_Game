using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatController : MonoBehaviour
{

    public Transform player;
    public float attackTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<Character>().life <= 0)
        {
            GetComponent<CircleCollider2D>().enabled = false;
            GetComponent<Rigidbody2D>().gravityScale = 0.5f;
            Destroy(gameObject, 3f);
            this.enabled = false;
        }


        if (Vector2.Distance(transform.position,player.position) > 0.2f)
        {
            attackTime = 0;
            transform.position = Vector2.MoveTowards(transform.position,player.position, 0.5f * Time.deltaTime);
        }
        else
        {
            attackTime = attackTime + Time.deltaTime;

            if (attackTime >= 1f)
            {
                attackTime = 0;
                player.GetComponent<Character>().life--;
            }
        }
    }
}
