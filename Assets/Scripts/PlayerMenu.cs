using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMenu : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    private bool canWalk = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartWalk());
    }

    // Update is called once per frame
    void Update()
    {
        if (canWalk)
            transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private IEnumerator StartWalk()
    {
        yield return new WaitForSeconds(0.1f);
        canWalk = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            SceneManager.LoadScene("Fase1");
        }
    }
}
