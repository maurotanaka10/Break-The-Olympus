using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaDoJogador : MonoBehaviour
{
    //Vida
    public int vidaMaximaDoJogador;
    public int vidaAtualDoJogador;

    //Escudo
    public bool temEscudo;
    public GameObject escudoDoJogador;
    public int vidaMaximaDoEscudo;
    public int vidaAtualDoEscudo;

    private Animator anima;

    // Start is called before the first frame update
    void Start()
    {
        vidaAtualDoJogador = vidaMaximaDoJogador;

        escudoDoJogador.SetActive(false);
        temEscudo = false;

        anima = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AtivarEscudo()
    {
        vidaAtualDoEscudo = vidaMaximaDoEscudo;

        escudoDoJogador.SetActive(true);
        temEscudo = true;
    }

    public void MachucarJogador(int danoParaReceber)
    {

        if(temEscudo == false)
        {
            vidaAtualDoJogador -= danoParaReceber;

            if (vidaAtualDoJogador <= 0)
            {
                anima.SetBool("pMorte", true);
                EfeitosSonoros.instance.somMorte.Play();
                Destroy(gameObject, 1.0f);
                GameManager.instance.GameOver();
            }
        }
        else
        {
            vidaAtualDoEscudo -= danoParaReceber;

            if (vidaAtualDoEscudo <= 0)
            {
                escudoDoJogador.SetActive(false);
                temEscudo = false;
            }
        }
    }
}
