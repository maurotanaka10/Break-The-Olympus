using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundScript : MonoBehaviour
{
    public float limiteX;
    public float limiteCima, limiteBaixo;
    public float velocidade;

    public GameObject secondPlatform;
    public float offset;

    //Aumentar velocidade com tempo
    public float defaulTimeLeft = 30f;
    private float timeLeft = 0;
    private float multiplicador = 1;
    public float multiplicadorPorSegundo = 0.05f;

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
            return;
        }

        timeLeft -= Time.deltaTime;

        if (timeLeft < 0)
        {
            multiplicador += multiplicadorPorSegundo;
            timeLeft = defaulTimeLeft;
        }

        if (transform.position.x < limiteX)
        {
            float alturaAtual = Random.Range(limiteBaixo, limiteCima);
            transform.position = new Vector2(secondPlatform.transform.position.x + offset, alturaAtual);
        }

        transform.Translate(Vector2.left * (velocidade * multiplicador) * Time.deltaTime);
    }
}
