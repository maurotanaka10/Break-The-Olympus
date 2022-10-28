using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Text textoDePontuacaoAtual;

    public GameObject painelGameOver;
    public Text textoDePontuacaoFinal;
    public Text textoHighScore;
    public TextMeshProUGUI teste ;

    public int pontuacaoAtual;

    public int pontuacaoDaFase;

    public bool gameIsOver;


    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        textoDePontuacaoAtual.text = "" + pontuacaoAtual;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        if (pontuacaoAtual >= pontuacaoDaFase)
        {
            SceneManager.LoadScene("Fase2");
        }

        if (gameIsOver)
            return;

        if (textoDePontuacaoAtual == null)
        {
            textoDePontuacaoAtual = GameObject.Find("Texto de Pontuacao").GetComponent<Text>();
        }

        pontuacaoAtual++;
        textoDePontuacaoAtual.text = "" + pontuacaoAtual;
    }

    public void AumentarPontuacao(int pontosParaGanhar)
    {
        pontuacaoAtual += pontosParaGanhar;
        textoDePontuacaoAtual.text = "" + pontuacaoAtual;
    }

    public void GameOver()
    {
        gameIsOver = true;
        painelGameOver.SetActive(true);
        textoDePontuacaoFinal.text = "" + pontuacaoAtual;

        if (pontuacaoAtual > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", pontuacaoAtual);
        }

        textoHighScore.text = "" + PlayerPrefs.GetInt("HighScore");
    }
}
