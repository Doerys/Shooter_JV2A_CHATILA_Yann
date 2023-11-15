using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : MonoBehaviour
{
    public GameObject alienBulletPrefab;

    private Rigidbody2D myRigidbody;

    public int remainHealth;
    public Player myPlayer;

    public float speedAlien;
    private float currentSpeedAlien;

    public VariableLibrary library;

    public float timerShoot;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = gameObject.GetComponent<Rigidbody2D>();

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

        // si le menu de pause du joueur est activé, l'alien cesse de se déplacer

        myRigidbody.velocity = new Vector2(0, -currentSpeedAlien);

        if (myPlayer.pauseMenu)
        {
            currentSpeedAlien = 0;
        }
        else
        {
            currentSpeedAlien = speedAlien;
        }

        if (gameObject.tag == "shooter")
        {
            Instantiate(alienBulletPrefab, transform.position, transform.rotation);
        }

        /*if ()
        {
            bulletTimer += Time.deltaTime;

            if ()
        }*/
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
