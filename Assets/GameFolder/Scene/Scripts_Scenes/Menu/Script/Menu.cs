using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
   public void NewGame(string name)
    {
        SceneManager.LoadScene(name);
    }

   public void CreditsGame(string name)
    {
        SceneManager.LoadScene(name);
    }


    public void ExitGame()
    {
        Application.Quit();
    }
}
