using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D bulletRigibody;
    public float speedBullet;
    private float currentSpeedBullet;

    public string typeBullet;

    public GameObject bonusPrefab;
    private Alien myTarget;
    public Player myPlayer;
 
    public VariableLibrary library;
    public FunctionLibrary functionLibrary;

    public ParticleSystem prefabExplosionParticleEmitter;

    private Vector3 directionBullet;

    // Start is called before the first frame update
    void Start()
    {
        // r�cup�rer le Rigidbody de la balle cr��e
        bulletRigibody = gameObject.GetComponent<Rigidbody2D>();
        
        library = FindAnyObjectByType<VariableLibrary>();

        functionLibrary = FindAnyObjectByType<FunctionLibrary>();

        myPlayer = FindAnyObjectByType<Player>();

        if (gameObject.tag != "alienBullet")
        {
            directionBullet = Vector3.up;           
        }

        else {
            directionBullet = Vector3.down;
        }

    }

    void Update()
    {

        if (gameObject.tag != "alienBullet")
        {
            // si la barre arrive trop haut dans l'espace de jeu, elle est d�truit
            if (transform.position.y > library.limitT.position.y)
            {
                Destroy(gameObject);
            }    
        }

        else {
            if (transform.position.y < library.limitB.position.y)
            {
                Destroy(gameObject);
            }
        }

        functionLibrary.Move(myPlayer, currentSpeedBullet, speedBullet, bulletRigibody, directionBullet);
        
        //library.PauseManager(myPlayer, currentSpeedBullet, speedBullet, bulletRigibody, directionBullet);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // si la balle trigger avec un mob
        if (gameObject.tag != "alienBullet" && (collision.gameObject.tag == "alien" || collision.gameObject.tag == "boss" || collision.gameObject.tag == "shooter"))
        {
            // on enregistre l'alien
            myTarget = collision.gameObject.GetComponent<Alien>();

            // perte de vie du mob
            myTarget.remainHealth --;
            
            // destruction de la balle
            Destroy(gameObject);

            // si le mob n'a plus de vie
            if (myTarget.remainHealth == 0)
            {
                Instantiate(prefabExplosionParticleEmitter, collision.gameObject.transform.position, collision.gameObject.transform.rotation);

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
