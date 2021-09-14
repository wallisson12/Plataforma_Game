using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrap1 : MonoBehaviour
{
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
            outro.transform.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            outro.transform.GetComponent<Rigidbody2D>().AddForce(new Vector2(0,150));
            outro.GetComponent<Character>().life--;
        }
    }
}
