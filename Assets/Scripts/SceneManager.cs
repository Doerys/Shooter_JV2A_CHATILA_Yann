using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SceneManager : MonoBehaviour
{
    public Player myPlayer;
    public int alienRemain = 48;
    public TextMeshProUGUI UIscore;
    public TextMeshProUGUI healthScore;

    // creating range for spawn
    public VariableLibrary library;

    //creating an interval for the spawn
    private float startDelay = 2f;
    private float spawnInterval = 3f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomEnemy", startDelay, spawnInterval);
        myPlayer = gameObject.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        UIscore.text = "Energy : " + myPlayer.score;
        healthScore.text = "Health : " + myPlayer.health;
    }

    void SpawnRandomEnemy()
    {
        Vector3 spawnPos = new Vector3(Random.Range(library.limitL.position.x, library.limitR.position.x), library.limitT.position.y, library.limitT.position.y);

        Instantiate(library.alienPrefab, spawnPos,
            library.alienPrefab.transform.rotation);
    }
}
