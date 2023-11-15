using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D myRigidbody;
    public float speedBullet;
    private float currentSpeedBullet;

    public string typeBullet;

    public GameObject bonusPrefab;

    private Alien myTarget;

    public Player myPlayer;

    public VariableLibrary library;

    private Vector3 directionBullet;

    // Start is called before the first frame update
    void Start()
    {
        // récupérer le Rigidbody de la balle créée
        myRigidbody = gameObject.GetComponent<Rigidbody2D>();
        
        library = FindObjectOfType<VariableLibrary>();

        myPlayer = FindAnyObjectByType<Player>();
    }

    void Update()
    {

        if (gameObject.tag != "alienBullet")
        {
            // si la barre arrive trop haut dans l'espace de jeu, elle est détruit
            if (transform.position.y > library.limitT.position.y)
            {
                Destroy(gameObject);
            }

            directionBullet = Vector3.up;           
        }

        else {
            if (transform.position.y < library.limitB.position.y)
            {
                Destroy(gameObject);
            }

            directionBullet = Vector3.down;
        }

        // si le menu de pause du joueur est activé, la balle cesse de monter
        myRigidbody.velocity = directionBullet * currentSpeedBullet;

        if (myPlayer.pauseMenu)
        {
            currentSpeedBullet = 0;
        }
        else
        {
            currentSpeedBullet = speedBullet;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // si la balle trigger avec un mob
        if (gameObject.tag != "alienBullet" && (collision.gameObject.tag == "alien" || collision.gameObject.tag == "boss"))
        {
            myTarget = collision.gameObject.GetComponent<Alien>();

            // perte de vie du mob
            myTarget.remainHealth -= 1;
            
            // destruction de la balle
            Destroy(gameObject);

            // si le mob n'a plus de vie
            if (myTarget.remainHealth == 0)
            {
                // destruction
                Destroy(collision.gameObject);

                // production de bonus
                int spawnProbability = Random.Range(1, 3);

                if (spawnProbability < 2)
                {
                    Instantiate(bonusPrefab, collision.gameObject.transform.position, collision.gameObject.transform.rotation);
                }
            }
        }

        else if (gameObject.tag == "alienBullet" && collision.gameObject.tag == "Player")
        {
            myPlayer.health--;

            Destroy(gameObject);
        }
    }
}
