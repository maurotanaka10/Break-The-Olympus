using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiroJogador : MonoBehaviour
{
    //Tiro
    public GameObject bulletProject;
    public Transform gun;
    public float shortSpeed;

    public int danoParaDar;

    private bool reloading;
    private int currentBullet;
    public int maxBullet = 3;
    public float timeReload;

    public GameObject municao1, municao2, municao3;

    //Tiro Especial
    public GameObject tiroEspecial;
    public bool temTiroEspecial;
    public float tempoMaximoDoTiroEspecial;
    public float tempoaAtualDoTiroEspecial;

    //animacao
    private Animator anima;

    // Start is called before the first frame update
    void Start()
    {
        temTiroEspecial = false;

        tempoaAtualDoTiroEspecial = tempoMaximoDoTiroEspecial;

        anima = GetComponent<Animator>();

        currentBullet = maxBullet;
    }

    // Update is called once per frame
    void Update()
    {
#if (UNITY_EDITOR)
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
#endif

        if (temTiroEspecial == true)
        {
            tempoaAtualDoTiroEspecial -= Time.deltaTime;

            if (tempoaAtualDoTiroEspecial <= 0)
            {
                DesativarTiroEspecial();
            }
        }
    }

    public void DisableAnimation()
    {
        anima.SetBool("pAtirar", false);
    }

    public void Shoot()
    {
        if (reloading)
            return;
        if (temTiroEspecial == false)
        {
            GameObject temp = Instantiate(bulletProject);
            temp.transform.position = gun.position;
            temp.GetComponent<Rigidbody2D>().velocity = new Vector2(shortSpeed, 0);
            EfeitosSonoros.instance.somTiroJogador.Play();
            Destroy(temp.gameObject, 1.2f);
        }
        else
        {
            GameObject temp = Instantiate(tiroEspecial);
            temp.transform.position = gun.position;
            temp.GetComponent<Rigidbody2D>().velocity = new Vector2(shortSpeed, 0);
            EfeitosSonoros.instance.somTiroEspecial.Play();
            Destroy(temp.gameObject, 1.2f);
        }

        currentBullet--;
        CheckBulletAmount();
        anima.SetBool("pAtirar", true);

        if(currentBullet == 2)
        {
            municao3.SetActive(false);
        }
        else if(currentBullet == 1)
        {
            municao2.SetActive(false);
        }
        else
        {
            municao1.SetActive(false);
        }
    }

    private void CheckBulletAmount()
    {
        if(currentBullet <= 0)
        {
            StartCoroutine(RateShoot(timeReload));
        }
    }

    private void DesativarTiroEspecial()
    {
        temTiroEspecial = false;
        tempoaAtualDoTiroEspecial = tempoMaximoDoTiroEspecial;
    }

    IEnumerator RateShoot(float timeReload)
    {
        reloading = true;
        yield return new WaitForSeconds(timeReload);
        currentBullet = maxBullet;
        municao1.SetActive(true);
        municao2.SetActive(true);
        municao3.SetActive(true);
        reloading = false;
    }
}
