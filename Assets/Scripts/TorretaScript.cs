using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorretaScript : MonoBehaviour
{
    public Rigidbody2D rb;

    //movimento
    public float velocidade;

    //Tiro inimigo
    public GameObject disparoInimigo;
    public Transform localDisparo;
    public float tempoDisparo;
    public float tempoAtualDoDisparo;

    //Atirar dentro do campo de visao
    private Transform alvo;
    public float raioVisao;
    public LayerMask layerAreaVisao;

    //Vida do inimigo
    public int vidaAtualDoInimigo;
    public int vidaMaximaDoInimigo;

    //Pontos
    public int pontosParaDar;

    //Aumentar velocidade com tempo
    public float defaulTimeLeft = 30f;
    private float timeLeft = 0;
    private float multiplicador = 1;
    public float multiplicadorPorSegundo = 0.05f;

    //Dano inimigo
    public int danoParaDar;

    private IEnumerator destroyCorroutine;

    // Start is called before the first frame update
    void Start()
    {
        vidaAtualDoInimigo = vidaMaximaDoInimigo;

        timeLeft = defaulTimeLeft;

        destroyCorroutine = SelfDestroy(6.0f);
        StartCoroutine(destroyCorroutine);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.gameIsOver)
        {
            if(destroyCorroutine != null)
            {
                StopCoroutine(destroyCorroutine);
            }
            return;
        }

        timeLeft -= Time.deltaTime;

        if (timeLeft < 0)
        {
            multiplicador += multiplicadorPorSegundo;
            timeLeft = defaulTimeLeft;
        }

        transform.Translate(Vector2.left * (velocidade * multiplicador) * Time.deltaTime);

        ProcurarJogador();
    }

    private IEnumerator SelfDestroy(float time)
    {
        yield return new WaitForSeconds(time);

        Destroy(this.gameObject);
    }

    private void AtirarDisparo()
    {
        tempoAtualDoDisparo -= Time.deltaTime;

        if (tempoAtualDoDisparo <= 0)
        {
            Instantiate(disparoInimigo, localDisparo.position, Quaternion.Euler(0f, 0f, 0f)); // Euler eh a rotacao do disparo
            tempoAtualDoDisparo = tempoDisparo;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(this.transform.position, this.raioVisao);
    }

    private void ProcurarJogador()
    {
        Collider2D colisor = Physics2D.OverlapCircle(this.transform.position, this.raioVisao, this.layerAreaVisao);
        if (colisor != null)
        {
            AtirarDisparo();
        }
    }

    public void MachucarInimigo(int danoParaReceber)
    {
        vidaAtualDoInimigo -= danoParaReceber;

        if (vidaAtualDoInimigo <= 0)
        {
            GameManager.instance.AumentarPontuacao(pontosParaDar);
            EfeitosSonoros.instance.somMorteTorreta.Play();
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<VidaDoJogador>().MachucarJogador(danoParaDar);
        }
    }

}
