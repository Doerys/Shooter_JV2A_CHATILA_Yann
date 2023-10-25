using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody2D monRigidBody;
    public float speed;

    public GameObject bonus;

    public Player myPlayer;

    private Alien myTarget;

    // Start is called before the first frame update
    void Start()
    {
        monRigidBody.velocity = Vector3.up * speed;

        myPlayer = gameObject.GetComponent<Player>();
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
                    Instantiate(bonus, collision.gameObject.transform.position, collision.gameObject.transform.rotation);
                }
            }
        }
    }
}
