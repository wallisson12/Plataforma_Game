using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Character : MonoBehaviour
{
    public int life;
    public Transform skin;
    public Transform Cam;

    public Text HealthCount;
    public Image DashBar;

    public AudioClip bossBattle, youWin;

    void Update()
    {
       
        if (life <= 0 && !transform.name.Equals("BossBrain"))
        {
            skin.GetComponent<Animator>().Play("Die",-1);
        }

        //Caso for o player
        if (this.gameObject.CompareTag("Player"))
        {
           
            HealthCount.text = "x" + life.ToString();
            DashBar.fillAmount = GetComponent<PlayerController>().dashTime;

            if (SceneManager.GetActiveScene().name.Equals("BossRoom"))
            {
                Cam.GetComponent<Animator>().enabled = false;
                Cam.GetComponent<Camera>().orthographicSize = 17.26f;
                Cam.position = new Vector3(4.5f,1.08f,-10f);
                Cam.parent = null;

                SceneManager.MoveGameObjectToScene(Cam.gameObject,SceneManager.GetActiveScene());

                if (GameObject.Find("BossBrain").GetComponent<Character>().life > 0)
                {
                    if (Cam.GetComponent<AudioSource>().clip != bossBattle && GetComponent<Character>().life > 0)
                    {
                        Cam.GetComponent<AudioSource>().clip = bossBattle;
                        Cam.GetComponent<AudioSource>().Play();
                    }
                }
                else
                {
                    GameObject.Find("YouWin").GetComponent<GameOver>().enabled = true;
                    GetComponent<PlayerController>().enabled = false;
                    GetComponent<CapsuleCollider2D>().enabled = false;
                    GetComponent<Rigidbody2D>().simulated = false;

                    if (Cam.GetComponent<AudioSource>().clip != youWin && GetComponent<Character>().life > 0)
                    {
                       Cam.GetComponent<AudioSource>().Stop();
                       Cam.GetComponent<AudioSource>().clip = youWin;
                       Cam.GetComponent<AudioSource>().PlayOneShot(youWin,1f);
                    }
                }
            }
        }

        //Caso for o boss
        if (transform.name.Equals("BossBrain"))
        {
            transform.GetChild(0).GetComponent<SpriteRenderer>().size = new Vector2(1.78f,(life * 1.09f / 50f));

            if (life <= 0)
            {
                GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;

            }
        }

    }

    public void PlayerDamage(int dano)
    {
        life -= dano;
        skin.GetComponent<Animator>().Play("PlayerDamage",1);
        Cam.GetComponent<Animator>().Play("CamDamage", -1);
        GetComponent<PlayerController>().audioSource.PlayOneShot(GetComponent<PlayerController>().damageSound,0.4f);

    }

    public void AddHeart(int valor)
    {
        life += valor;
    }
}
