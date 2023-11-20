using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SceneManager : MonoBehaviour
{
    public Player myPlayer;
    public TextMeshProUGUI UIscore;
    public Image healthBar ;

    public VariableLibrary library;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // change le texte des UI en fonction du temps
        UIscore.text = myPlayer.energy.ToString();
        healthBar.fillAmount = myPlayer.health * 10;

        Debug.Log(healthBar.fillAmount);
    }

    void SpawnRandomEnemy()
    {
        // Position du spawn
        Vector3 spawnPos = new Vector3(Random.Range(library.limitL.position.x, library.limitR.position.x), library.limitT.position.y, library.limitT.position.y);

        Instantiate(library.alienPrefab, spawnPos,
            library.alienPrefab.transform.rotation);
    }
}
