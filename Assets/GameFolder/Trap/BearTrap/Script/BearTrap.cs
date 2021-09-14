using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearTrap : MonoBehaviour
{

    Transform player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D outro)
    {
        if (outro.CompareTag("Player"))
        {
            player = outro.transform;
            transform.GetComponentInChildren<Animator>().Play("BearTrap", -1);

            outro.transform.position = transform.position;
            outro.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

            outro.GetComponent<Character>().life--;
            outro.GetComponent<PlayerController>().skin.GetComponent<Animator>().SetBool("PlayerRun", false);
            outro.GetComponent<PlayerController>().enabled = false;

            GetComponent<BoxCollider2D>().enabled = false;
            Invoke("RealeasePlayer",1);
        }
    }

    void RealeasePlayer()
    {
        player.GetComponent<PlayerController>().enabled = true;
    }
}
