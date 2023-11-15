using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SceneManager : MonoBehaviour
{
    public Player myPlayer;
    public int alienRemain = 48;
    public TextMeshProUGUI UIscore;
    public TextMeshProUGUI UIhealth;

    public VariableLibrary library;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // change le texte des UI en fonction du temps
        UIscore.text = "Energy : " + myPlayer.score;
        UIhealth.text = "Health : " + myPlayer.health;
    }

    void SpawnRandomEnemy()
    {
        // Position du spawn
        Vector3 spawnPos = new Vector3(Random.Range(library.limitL.position.x, library.limitR.position.x), library.limitT.position.y, library.limitT.position.y);

        Instantiate(library.alienPrefab, spawnPos,
            library.alienPrefab.transform.rotation);
    }
}
