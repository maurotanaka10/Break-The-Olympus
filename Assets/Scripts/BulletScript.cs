using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public int dano;
    public bool specialBullet;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyScript>().MachucarInimigo(dano);
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "EnemyTorreta")
        {
            collision.gameObject.GetComponent<TorretaScript>().MachucarInimigo(dano);
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Ground")
        {
            Destroy(gameObject);
        }

        if(specialBullet)
        {
            if (collision.gameObject.tag == "Obstacle")
            {
                Destroy(gameObject);
                Destroy(collision.gameObject);
            }
        }
    }
}
