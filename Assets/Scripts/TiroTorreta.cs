using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiroTorreta : MonoBehaviour
{
    public float velocidadeDisparo;
    public Rigidbody2D rb;
    private GameObject target;

    private Vector2 direcaoMovimento;

    public int danoParaDar;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        GameObject target = GameObject.FindGameObjectWithTag("Player");
        direcaoMovimento = (target.transform.position - transform.position).normalized * velocidadeDisparo;
        rb.velocity = new Vector2(direcaoMovimento.x, direcaoMovimento.y);
        Destroy(gameObject, 10f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<VidaDoJogador>().MachucarJogador(danoParaDar);
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Ground")
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Obstacle")
        {
            Destroy(gameObject);
        }
    }
}
