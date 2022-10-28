using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScript : MonoBehaviour
{
    //Velocidade
    public float velocidade;

    //Dano no jogador
    public int danoParaDar;

    //Aumentar velocidade com tempo
    public float defaulTimeLeft = 30f;
    private float timeLeft = 0;
    private float multiplicador = 1;
    public float multiplicadorPorSegundo = 0.05f;

    private IEnumerator destroyCorroutine;

    // Start is called before the first frame update
    void Start()
    {
        timeLeft = defaulTimeLeft;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.gameIsOver)
        {
            if (destroyCorroutine != null)
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
        Destroy(gameObject, 6.0f);
    }

    private IEnumerator SelfDestroy(float time)
    {
        yield return new WaitForSeconds(time);

        Destroy(this.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<VidaDoJogador>().MachucarJogador(danoParaDar);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "BulletPlayer")
        {
            Destroy(collision.gameObject);
        }
    }
}
