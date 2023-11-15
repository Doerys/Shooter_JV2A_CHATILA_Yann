using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    public GameObject bigBullet;
    public GameObject bullet;
    public GameObject laserPrefab;
    public Transform parent;
    public Transform limitL;
    public Transform limitR;
    public int score;

    private float speed = 0.2f;
    public int health = 5;

    public bool pauseMenu = false;

    public Weapons actualWeapon = Weapons.ClassicBullet;

    public int alienRemain = 48;

    private float timerLaserAbility = 3;
    private bool decreaseTimerLaser = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!pauseMenu)
        {
            // change la position du vaisseau sur l'axe X. Figé sur l'axe Y.
            Vector2 mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            mousePos.y = -4.57f;
            transform.position = mousePos;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                //active une variable qui pause le jeu, et active un menu.


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

                        Vector3 temporaryPosition;

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
                            if (timerLaserAbility >= 1.5f)
                            {
                                Vector3 position = parent.position;

                                position.y = parent.position.y + 2;

                                Instantiate(laserPrefab, position, parent.rotation);

                                timerLaserAbility = 0;
                            }
                        }
                        break;
                    default:
                        break;
                }
            }

            if (decreaseTimerLaser)
            {
                if (timerLaserAbility < 1.5f)
                {
                    timerLaserAbility += Time.deltaTime;
                }
            }

            if (Input.GetKeyDown(KeyCode.LeftShift) && score >= 10)
            {
                actualWeapon = Weapons.Laser;

                score -= 10;

                decreaseTimerLaser = true;
            }
        }

        if (Input.GetKey(KeyCode.Space))
        {

            pauseMenu = true;

            //actualWeapon = Weapons.DoubleBullet;

            //score -= 10;
        }

        else
        {
            pauseMenu = false;
        }

    }


}

public enum Weapons
{
    ClassicBullet,
    DoubleBullet,
    Laser
}
