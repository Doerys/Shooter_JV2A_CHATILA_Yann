using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
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

    public int energy;
    public int health;
    public int score;

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
            Debug.Log(limitL.position.x + " EST INFERIEUR A " + Input.mousePosition.x + " EST INFERIEUR A " + limitR.position.x);

            // change la position du vaisseau sur l'axe X. Fig� sur l'axe Y.
            if (Input.mousePosition.x > limitL.position.x || Input.mousePosition.x < limitR.position.x)
            {
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
                        Instantiate(bullet, parent.position, parent.rotation);
                        break;

                    // Si on a la Double Bullet
                    case Weapons.DoubleBullet:

                        if (energy >= 1)
                        {
                            temporaryPosition = parent.position;

                            temporaryPosition.x -= 1;

                            energy--;

                            for (int i = 0; i < 2; i++)
                            {
                                Instantiate(bullet, temporaryPosition, parent.rotation);

                                temporaryPosition.x += 2;
                            }
                        }

                        else
                        {
                            actualWeapon = Weapons.ClassicBullet;
                            Instantiate(bullet, parent.position, parent.rotation);
                        }

                        break;

                    // Si on a le laser
                    case Weapons.Laser:
                        {
                            if (!activeLaser)
                            {
                                if (energy >= 5)
                                {
                                    energy -= 5;

                                    Vector3 position = transform.position;

                                    position.y = transform.position.y + 2;

                                    Instantiate(laserPrefab, position, transform.rotation);

                                    timerLaserAbility = 2f;

                                    activeLaser = true;
                                }

                                else
                                {
                                    actualWeapon = Weapons.ClassicBullet;
                                    Instantiate(bullet, parent.position, parent.rotation);
                                }
                            }
                        }
                        break;

                    // si on a le shield
                    case Weapons.Shield:
                        {
                            if (!activeShield)
                            {
                                if (energy >= 10)
                                {
                                    energy -= 10;

                                    Instantiate(shieldPrefab, transform.position, transform.rotation);

                                    activeShield = true;
                                }

                                else
                                {
                                    actualWeapon = Weapons.ClassicBullet;
                                    Instantiate(bullet, parent.position, parent.rotation);
                                }
                            }
                        }
                        break;

                    default:
                        break;
                }
            }

            if (activeLaser)
            {
                if (timerLaserAbility < 2f)
                {
                    timerLaserAbility += Time.deltaTime;
                }
                else
                {
                    activeLaser = false;
                }
            }

            if (activeShield)
            {
                if (timerShieldAbility < 4f)
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

        if (health <= 0)
        {
            Destroy(gameObject);
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
