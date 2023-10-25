using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : MonoBehaviour
{
    private Rigidbody2D myRigidbody;

    public int remainHealth;
    public Player myPlayer;

    public float speed;

    public VariableLibrary library;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = gameObject.GetComponent<Rigidbody2D>();
        myRigidbody.velocity = new Vector2(0, -speed);

        myPlayer = FindAnyObjectByType<Player>();

        library = FindAnyObjectByType<VariableLibrary>();

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < library.limitB.transform.position.y)
        {
            Destroy(gameObject);
            myPlayer.health--;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            myPlayer = collision.gameObject.GetComponent<Player>();

            myPlayer.health--;
            
            Destroy(gameObject);
        }
    }
}
