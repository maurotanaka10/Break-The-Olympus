using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public float limitX;
    public GameObject player;
    public float speed;

    private Animator anima;

    // Start is called before the first frame update
    void Start()
    {
        anima = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            anima.SetBool("pComecou", true);
            player.SetActive(true);
        }

        if (player.transform.position.x >= limitX)
        {
            SceneManager.LoadScene("Fase1");
        }
    }
}
