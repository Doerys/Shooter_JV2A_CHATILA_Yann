using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{

    public float timerSpawn;
    private float timerDifficulty;

    public float minTime;
    public float maxTime;

    private int randomTypeAlien;

    public GameObject prefabAlien;
    public GameObject prefabBossAlien;
    public GameObject prefabShooterAlien;

    public Player myPlayer;

    // Start is called before the first frame update
    void Start()
    {
        // timer
        timerSpawn = Random.Range(minTime, maxTime);

        myPlayer = FindAnyObjectByType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!myPlayer.pauseMenu)
        {
            // progression du temps au fur et � mesure du temps
            timerSpawn -= Time.deltaTime;

            // permet d'instancier si on fait poper des mobs tr�s puissantS

            randomTypeAlien = Random.Range(0, 9);

            if (timerSpawn <= 0)
            {
                timerSpawn = Random.Range(minTime, maxTime) - timerDifficulty;

                if (timerDifficulty < 5)
                {
                    timerDifficulty += .5f;
                }

                // creation aliens
                if (randomTypeAlien == 6)
                {
                    Instantiate(prefabBossAlien, transform.position, transform.rotation);
                }

                // creation boss
                else if (randomTypeAlien == 7)
                {
                    Instantiate(prefabShooterAlien, transform.position, transform.rotation);
                }
                
                else
                {
                    Instantiate(prefabAlien, transform.position, transform.rotation);
                }
            }
        }
    }
}
