using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostController : MonoBehaviour
{
    public Transform skin;
    public Transform a;
    public Transform b;

    public bool isRight;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isRight == true)
        {
            skin.localScale = new Vector3(-1,1,1);

            if (Vector2.Distance(transform.position,b.position) < 0.1f)
            {
                transform.position = a.position;
            }

             transform.position = Vector2.MoveTowards(transform.position,b.position,15f * Time.deltaTime);

        }else
        {
            skin.localScale = new Vector3(1,1,1);

            if (Vector2.Distance(transform.position,a.position) < 0.1f)
            {
                transform.position = b.position;
            }

             transform.position = Vector2.MoveTowards(transform.position,a.position,13f * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D outro)
    {
        if (outro.CompareTag("Player"))
        {
            outro.GetComponent<Character>().PlayerDamage(1);
        }
    }
}
