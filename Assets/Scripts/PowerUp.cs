using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public Rigidbody2D rb;
    public float velocidade;

    public bool powerEscudo;
    public bool powerTiroEspecial;

    private void Update()
    {
        if (GameManager.instance.gameIsOver)
            return;

        transform.Translate(Vector2.left * velocidade * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            EfeitosSonoros.instance.somPowerUp.Play();

            int a = Random.Range(0, 2);

            if (a == 0)
            {
                powerEscudo = true;
                print("true");
            }
            else
            {
                powerTiroEspecial = true;
                print("false");
            }

            if(powerEscudo == true)
            {
                collision.gameObject.GetComponent<VidaDoJogador>().AtivarEscudo();
            }
            if (powerTiroEspecial == true)
            {
                collision.gameObject.GetComponent<TiroJogador>().temTiroEspecial = false;
                collision.gameObject.GetComponent<TiroJogador>().tempoaAtualDoTiroEspecial = collision.gameObject.GetComponent<TiroJogador>().tempoMaximoDoTiroEspecial;
                collision.gameObject.GetComponent<TiroJogador>().temTiroEspecial = true;
            }

            Destroy(gameObject);
        }
    }
}
