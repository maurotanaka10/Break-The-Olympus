using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenarioLaboratorioScript : MonoBehaviour
{
    public float limiteX;
    public float velocidade;
    public float offset;
    public GameObject segundoCenario;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.gameIsOver)
            return;

        transform.Translate(Vector2.left * velocidade * Time.deltaTime);

        if(transform.position.x < limiteX)
        {
            transform.position = new Vector2(segundoCenario.transform.position.x + offset, transform.position.y);
        }
    }
}
