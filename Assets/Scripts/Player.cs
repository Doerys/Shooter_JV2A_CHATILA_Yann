using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    public GameObject bigBullet;
    public GameObject bullet;
    public GameObject laserPrefab;
    public GameObject shieldPrefab;

    public GameObject bulletButton;
    public GameObject doubleBulletButton;
    public GameObject laserButton;
    public GameObject shieldButton;

    public Transform parent;
    public Transform limitL;
    public Transform limitR;
    public int score;

    public int health = 10;

    public bool pauseMenu = false;

    public Weapons actualWeapon = Weapons.ClassicBullet;

    public int alienRemain = 48;

    private float timerLaserAbility;
    private bool activeLaser = false;

    private float timerShieldAbility;
    private bool activeShield = false;

    private Vector3 temporaryPosition;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!pauseMenu)
        {
            if (!activeShield)
            {
                // change la position du vaisseau sur l'axe X. Fig� sur l'axe Y.
                Vector2 mousePos = Input.mousePosition;
                mousePos = Camera.main.ScreenToWorldPoint(mousePos);
                mousePos.y = -3.62f;
                transform.position = mousePos;
            }

            // Clic gauche => tir
            if (Input.GetMouseButtonDown(0))
            {

                switch (actualWeapon)
                {
                    // Si on a l'actuelle Weapon
                    case Weapons.ClassicBullet:
                        Instantiate(bigBullet, parent.position, parent.rotation);
                        break;

                    // Si on a la Double Bullet
                    case Weapons.DoubleBullet:

                        temporaryPosition = parent.position;

                        temporaryPosition.x -= 1;

                        for (int i = 0; i < 2; i++)
                        {
                            Instantiate(bullet, temporaryPosition, parent.rotation);

                            temporaryPosition.x += 2;
                        }
                        break;

                    // Si on a le laser
                    case Weapons.Laser:
                        {
                            if (!activeLaser)
                            {
                                Vector3 position = parent.position;

                                position.y = parent.position.y + 2;

                                Instantiate(laserPrefab, position, parent.rotation);

                                timerLaserAbility = 0;
                            }
                        }
                        break;

                    // si on a le shield
                    case Weapons.Shield:
                        {
                            if (!activeShield)
                            {
                                temporaryPosition = parent.position;;

                                Instantiate(shieldPrefab, temporaryPosition, parent.rotation);

                                activeShield = true;
                            }
                        }
                        break;

                    default:
                        break;
                }
            }

            if (activeLaser)
            {
                if (timerLaserAbility < 1.5f)
                {
                    timerLaserAbility += Time.deltaTime;
                }
                else
                {
                    timerLaserAbility = 0f;
                    activeLaser = false;
                }
            }

            if (activeShield)
            {
                if (timerShieldAbility < 1.5f)
                {
                    timerShieldAbility += Time.deltaTime;
                }
                else
                {
                    timerShieldAbility = 0f;
                    activeShield = false;
                }
            }
        }

        //active une variable qui pause le jeu, et active un menu.

        if (Input.GetKey(KeyCode.Space))
        {
            pauseMenu = true;

            bulletButton.SetActive(true);
            doubleBulletButton.SetActive(true);
            laserButton.SetActive(true);
            shieldButton.SetActive(true);
        }

        else
        {

            bulletButton.SetActive(false);
            doubleBulletButton.SetActive(false);
            laserButton.SetActive(false);
            shieldButton.SetActive(false);

            pauseMenu = false;
        }
    }
    public void ActivateBullet()
    {
        actualWeapon = Weapons.ClassicBullet;
    }

    public void ActivateDoubleBullet()
    {
        actualWeapon = Weapons.DoubleBullet;
    }
    public void ActivateLaser()
    {
        actualWeapon = Weapons.Laser;
    }
    public void ActivateShield()
    {
        actualWeapon = Weapons.Shield;
    }

}



public enum Weapons
{
    ClassicBullet,
    DoubleBullet,
    Laser,
    Shield
}
