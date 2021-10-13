using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Character : MonoBehaviour
{
    public int life;
    public Transform skin;
    public Transform Cam;

    public Image HealthBar;
    public Image DashBar;

    void Update()
    {
       
        if (life <= 0)
        {
            skin.GetComponent<Animator>().Play("Die",-1);
        }

        if (this.gameObject.CompareTag("Player"))
        {
            HealthBar.fillAmount = (float)life/100;
            DashBar.fillAmount = GetComponent<PlayerController>().dashTime;
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
