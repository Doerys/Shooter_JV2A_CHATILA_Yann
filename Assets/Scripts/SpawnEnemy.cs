using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{

    public float timerSpawn;

    public float minTime;
    public float maxTime;

    public int createMinions = 0;

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
            // progression du temps au fur et à mesure du temps
            timerSpawn -= Time.deltaTime;

            // permet d'instancier si on fait poper des mobs très puissantS

            createMinions = Random.Range(0, 9);

            if (timerSpawn <= 0)
            {
                timerSpawn = Random.Range(minTime, maxTime);

                // creation aliens
                if (createMinions == 6)
                {
                    Instantiate(prefabBossAlien, transform.position, transform.rotation);
                    timerSpawn = Random.Range(minTime, maxTime);
                }

                // creation boss
                else if (createMinions == 7)
                {
                    Debug.Log("CREATION SHOOTER");
                    Instantiate(prefabShooterAlien, transform.position, transform.rotation);
                    timerSpawn = Random.Range(minTime, maxTime);
                }
                
                else
                {
                    Instantiate(prefabAlien, transform.position, transform.rotation);
                    timerSpawn = Random.Range(minTime, maxTime);
                }
            }
        }
    }
}
