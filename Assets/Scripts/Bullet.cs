using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D myRigidbody;
    public float speed;

    public GameObject bonusPrefab;

    private Alien myTarget;

    public VariableLibrary library;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = gameObject.GetComponent<Rigidbody2D>();
        myRigidbody.velocity = Vector3.up * speed;
        library = FindObjectOfType<VariableLibrary>();
    }

    void Update()
    {
        if (transform.position.y > library.limitT.position.y)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "alien" || collision.gameObject.tag == "boss")
        {

            myTarget = collision.gameObject.GetComponent<Alien>();

            myTarget.remainHealth -= 1;
            print(myTarget.remainHealth);
            Destroy(gameObject);

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
