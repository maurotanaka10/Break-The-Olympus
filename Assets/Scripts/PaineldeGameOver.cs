using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PaineldeGameOver : MonoBehaviour
{
    public void ReiniciarJogo()
    {
        SceneManager.LoadScene("Fase1");
    }

    public void TelaDeMenu()
    {
        SceneManager.LoadScene("Menu");

    }

    public void SairDoJogo()
    {
        Application.Quit();
    }
}
