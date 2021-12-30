using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VoltaMenu : MonoBehaviour
{
  public void BackMenu(string nome)
  {
        SceneManager.LoadScene(nome);
  }
}
