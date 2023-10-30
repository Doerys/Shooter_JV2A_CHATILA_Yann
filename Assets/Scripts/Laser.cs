using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    Player myPlayer;

    private Alien myTarget;

    public GameObject bonusPrefab;

    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        myPlayer = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 1.5f)
        {
            Destroy(gameObject);
        }

        float yPosition = myPlayer.transform.position.y;

        transform.position.y = yPosition;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "alien" || collision.gameObject.tag == "boss")
        {

            myTarget = collision.gameObject.GetComponent<Alien>();

            myTarget.remainHealth -= 1;

            if (myTarget.remainHealth == 0)
            {
                Destroy(collision.gameObject);

                int spawnProbability = Random.Range(1, 3);

                if (spawnProbability < 2)
                {
                    Instantiate(bonusPrefab, collision.gameObject.transform.position, collision.gameObject.transform.rotation);
                }
            }
        }
    }
}
