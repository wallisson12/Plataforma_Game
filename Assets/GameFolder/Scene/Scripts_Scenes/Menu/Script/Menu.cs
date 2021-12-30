using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
   public void NewGame(string name)
    {
        StartCoroutine(chamaScene(name));
    }

   public void CreditsGame(string name)
    {
        StartCoroutine(chamaScene(name));
    }


    public void ExitGame()
    {
        Application.Quit();
    }

    IEnumerator chamaScene(string nome)
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(nome);
    }
}
