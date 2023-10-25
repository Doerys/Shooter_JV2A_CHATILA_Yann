using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{

    public float timer;

    public float minTime;
    public float maxTime;

    public int createMinions = 0;

    public GameObject prefabAlien;
    public GameObject prefabBossAlien;

    // Start is called before the first frame update
    void Start()
    {
        timer = Random.Range(minTime, maxTime);
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        Debug.Log(timer);

        if (timer<= 0)
        {
            // creation aliens
            if (createMinions < 5)
            {
                createMinions += 1;
                Instantiate(prefabAlien, transform.position, transform.rotation);
                timer = Random.Range(minTime, maxTime);
            }

            // creation boss

            else
            {
                Instantiate(prefabBossAlien, transform.position, transform.rotation);
                timer = Random.Range(minTime, maxTime);
                createMinions = 0;
            }
        }
    }
}
