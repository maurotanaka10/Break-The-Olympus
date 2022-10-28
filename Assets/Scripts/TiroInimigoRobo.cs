using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiroInimigoRobo : MonoBehaviour
{
    public float velocidadeDoDisparo;
    public int danoParaDar;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MovimentarDisparo();
    }

    private void MovimentarDisparo()
    {
        transform.Translate(Vector3.left * velocidadeDoDisparo * Time.deltaTime);
        Destroy(gameObject, 2f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<VidaDoJogador>().MachucarJogador(danoParaDar);
            Destroy(gameObject);
        }

        if(collision.gameObject.tag == "Obstacle")
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "TiroEspecial")
        {
            Destroy(gameObject);
        }
    }
}
