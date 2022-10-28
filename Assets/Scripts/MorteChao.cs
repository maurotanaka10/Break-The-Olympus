using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MorteChao : MonoBehaviour
{
    public int danoParaDar;

    // Start is called before the first frame update
    void Start()
    {

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
            EfeitosSonoros.instance.somMorteRobo.Play();
        }
    }
}
