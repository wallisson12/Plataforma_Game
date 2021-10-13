using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Level1Leve2 : MonoBehaviour
{
    public string nameScene;
    public Animator anim;
 
    void OnTriggerEnter2D(Collider2D outro)
    {
        if (outro.CompareTag("Player"))
        {

            Transition(nameScene);

        }
        
    }

    public void Transition(string nameScene)
    {
        StartCoroutine(LoadScene(nameScene));
    }

    IEnumerator LoadScene(string nameScene)
    {
        anim.SetTrigger("Start");

        yield return new WaitForSeconds(0.5f);

        SceneManager.LoadScene(nameScene);


    }
}
