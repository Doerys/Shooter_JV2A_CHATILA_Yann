using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SceneManager : MonoBehaviour
{
    public Player myPlayer;

    public TextMeshProUGUI scoreUI;
    public TextMeshProUGUI energyUI;
    public Image healthBar;

    public Image bulletIcon;
    public Image doubleBulletIcon;
    public Image laserIcon;
    public Image shieldIcon;

    public TextMeshProUGUI gameOver;
    public TextMeshProUGUI scoreTxt;
    public TextMeshProUGUI scoreNumber;
    public Button retryButton;

    public VariableLibrary library;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (myPlayer.isAlive)
        {
            if (myPlayer.actualWeapon == Weapons.ClassicBullet)
            {

                bulletIcon.enabled = true;
                doubleBulletIcon.enabled = false;
                laserIcon.enabled = false;
                shieldIcon.enabled = false;

            }

            else if (myPlayer.actualWeapon == Weapons.DoubleBullet)
            {

                bulletIcon.enabled = false;
                doubleBulletIcon.enabled = true;
                laserIcon.enabled = false;
                shieldIcon.enabled = false;

            }

            else if (myPlayer.actualWeapon == Weapons.Laser)
            {

                bulletIcon.enabled = false;
                doubleBulletIcon.enabled = false;
                laserIcon.enabled = true;
                shieldIcon.enabled = false;

            }

            else
            {

                bulletIcon.enabled = false;
                doubleBulletIcon.enabled = false;
                laserIcon.enabled = false;
                shieldIcon.enabled = true;

            }

            // change le nombre d energie en temps réel
            energyUI.text = myPlayer.energy.ToString();

            // enlève une partie de la barre de vie en fonction du nombre de pv 
            float actualHealth = myPlayer.health / 10f;
            healthBar.fillAmount = actualHealth;

            // change le score en temps réel
            scoreUI.text = myPlayer.score.ToString();
        }
    }

    void SpawnRandomEnemy()
    {
        // Position du spawn
        Vector3 spawnPos = new Vector3(Random.Range(library.limitL.position.x, library.limitR.position.x), library.limitT.position.y, library.limitT.position.y);

        Instantiate(library.alienPrefab, spawnPos,
            library.alienPrefab.transform.rotation);
    }
}
