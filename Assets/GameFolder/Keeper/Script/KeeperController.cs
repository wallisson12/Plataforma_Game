using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeeperController : MonoBehaviour
{
    public Transform a;
    public Transform b;
    public Transform skin;
    public Transform keeperRange;

    public AudioSource audioSource;
    public AudioClip die;

    public bool goRight;

    public int  lifeAtual;

    void Start()
    {
        lifeAtual = GetComponent<Character>().life;
    }
    void Update()
    {
        if (GetComponent<Character>().life <= 0)
        {
            GetComponent<Character>().life = 0;
            audioSource.PlayOneShot(die,0.3f);
            GetComponent<CapsuleCollider2D>().enabled = false;
            keeperRange.GetComponent<CircleCollider2D>().enabled = false;
            this.enabled = false;
            Destroy(gameObject,3f);

        }

        if (lifeAtual != GetComponent<Character>().life)
        {
            lifeAtual = GetComponent<Character>().life;
            skin.GetComponent<Animator>().Play("KeeperDamage",1);
        }

        if (skin.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("KeeperAttack"))
        {
            return;
        }

        if (goRight == true)
        {
            skin.localScale = new Vector3(1,1,1);

            if (Vector2.Distance(transform.position,b.position) < 0.4f)
            {
                goRight = false;
            }

             transform.position = Vector2.MoveTowards(transform.position, b.position, 1.5f * Time.deltaTime);

        }else
        {
            skin.localScale = new Vector3(-1, 1, 1);

            if (Vector2.Distance(transform.position, a.position) < 0.4f)
            {
                goRight = true;
            }
            transform.position = Vector2.MoveTowards(transform.position, a.position, 1.5f * Time.deltaTime);
        }
    }
}
