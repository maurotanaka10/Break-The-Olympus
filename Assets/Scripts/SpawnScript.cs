using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    public float intervaloMin, intervaloMax;
    public GameObject enemyPrefab;

    public float defaulTimeLeft = 30;
    private float timeLeft = 0;
    private float multiplicador = 0;
    public float multiplicadorPorSegundo = 0.05f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn(intervaloMin, intervaloMax));
        timeLeft = defaulTimeLeft;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.gameIsOver)
            return;

        timeLeft -= Time.deltaTime;

        if (timeLeft < 0)
        {
            multiplicador += multiplicadorPorSegundo;
            timeLeft = defaulTimeLeft;
        }
    }

    IEnumerator Spawn(float min, float max)
    {
        yield return new WaitForSeconds(Random.Range(min, max));
        TryInstantiate(enemyPrefab);
        StartCoroutine(Spawn(min, max * (1 - multiplicador)));

    }

    public void TryInstantiate(GameObject enemyPrefab)
    {

        Collider2D[] hitColliders = Physics2D.OverlapBoxAll(new Vector2(this.transform.position.x, this.transform.position.y - 2), new Vector2(5f, 7f), 0f);
        if (hitColliders != null)
        {
            bool canSpawn = false;

            foreach (Collider2D item in hitColliders)
            {
                if (item.gameObject.layer == LayerMask.NameToLayer("Ground"))
                {
                    canSpawn = true;
                    continue;
                }
                else
                {
                    break;
                }
            }

            if (canSpawn)
            {
                Instantiate(enemyPrefab);
            }
        }
    }
}
