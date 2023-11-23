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

    private FunctionLibrary functionLibrary;

    public ParticleSystem prefabExplosionParticleEmitter;

    public float timerShoot;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = gameObject.GetComponent<Rigidbody2D>();

        myPlayer = FindAnyObjectByType<Player>();

        library = FindAnyObjectByType<VariableLibrary>();

        functionLibrary = FindAnyObjectByType<FunctionLibrary>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < library.limitB.transform.position.y)
        {
            Destroy(gameObject);

            if (myPlayer.score >= 2)
            {
                myPlayer.score -= 2;
            }

            else if (myPlayer.score > 0)
            {
                myPlayer.score --;
            }
        }

        // si le menu de pause du joueur est activ�, l'alien cesse de se d�placer

        myRigidbody.velocity = new Vector2(0, -currentSpeedAlien);

        if (myPlayer.pauseMenu)
        {
            currentSpeedAlien = 0;
        }
        else
        {
            currentSpeedAlien = speedAlien;
        }

        if (!myPlayer.isAlive)
        {
            Instantiate(prefabExplosionParticleEmitter, transform.position, transform.rotation);

            Destroy(gameObject);
        }

        if (gameObject.tag == "shooter")
        {
            timerShoot += Time.deltaTime;

            if (timerShoot >= 2.5f){
                Instantiate(alienBulletPrefab, transform.position, transform.rotation);
                timerShoot = 0;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            myPlayer = collision.gameObject.GetComponent<Player>();

            if (!myPlayer.isInvulnerable)
            {
                functionLibrary.InvulnerabilityFrames(myPlayer);
            }

            Instantiate(prefabExplosionParticleEmitter, transform.position, transform.rotation);

            Destroy(gameObject);
        }
    }
}
