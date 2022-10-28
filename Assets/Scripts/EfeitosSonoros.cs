using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EfeitosSonoros : MonoBehaviour
{
    public static EfeitosSonoros instance;

    public AudioSource somPulo, somMorte, somTiroJogador, somTiroRobo, somTiroTorreta, somMorteTorreta, somMorteRobo, somTiroEspecial, somPowerUp;

    private void Awake()
    {
        instance = this;
    }
}
