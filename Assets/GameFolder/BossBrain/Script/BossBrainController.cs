using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBrainController : MonoBehaviour
{
    public Transform A, B;
    public Vector3 targetPosition;

    //Para o laser
    public Transform laser;
    public float laserTime;

    public AudioClip bossLaugh , laserClip;

    void Start()
    {
        targetPosition = A.position;

        BossLaugh();
    }

    
    void Update()
    {
        //Se o boss morrer
        if (GetComponent<Character>().life <= 0)
        {
            return;
        }

        // Faz com que o laser ative e desative e volte para a position do boss
        laserTime += Time.deltaTime;

        //Faz o laser voltar para a posição de origem
        if (laserTime > 6)
        {
            GetComponent<AudioSource>().PlayOneShot(laserClip,0.2f);

            laserTime = 0;
            laser.gameObject.SetActive(false);
            //Usado para limpar a area de trilhagem, quando ele(laser) for realocado no boss
            laser.GetComponentInChildren<TrailRenderer>().Clear();
            laser.position = transform.position;
            laser.gameObject.SetActive(true);
        }

        //Movimentação do boss
        if (transform.position == A.position)
        {
            targetPosition = B.position;
        }

        if (transform.position == B.position)
        {
            targetPosition = A.position;
        }

        transform.position = Vector2.MoveTowards(transform.position, targetPosition, 5 * Time.deltaTime);
    }

    void BossLaugh()
    {
        Invoke("BossLaugh",15f);
        GetComponent<AudioSource>().PlayOneShot(bossLaugh,0.2f);
    }
}
