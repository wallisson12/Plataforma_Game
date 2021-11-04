using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public Transform Player;

    void OnEnable()
    {
        Player = GameObject.Find("Player").transform;

        //Aqui o eixo vai rotacionar para onde o Player estiver na cena
        transform.right = transform.position - Player.position; 
    }

    void Update()
    {
        //Aqui a minha posição esta sendo atualizada e se movimentando para o eixo que esta apontado para o player 
        transform.position += transform.right * -8 * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D outro)
    {
        if (outro.CompareTag("Player"))
        {
            outro.GetComponent<Character>().PlayerDamage(1);
        }
    }
}
