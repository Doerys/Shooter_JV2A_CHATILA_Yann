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
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // si la balle trigger avec un mob
        if (gameObject.tag != "alienBullet")
        {
            functionLibrary.CheckTriggerWeapon(collision, gameObject);
        }

        else if (gameObject.tag == "alienBullet" && collision.gameObject.tag == "Player")
        {
            myPlayer.health--;

            Destroy(gameObject);
        }
    }
}
