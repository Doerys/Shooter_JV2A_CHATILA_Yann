using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    public GameObject bullet;
    public GameObject laserPrefab;
    public Transform parent;
    public Transform limitL;
    public Transform limitR;
    public int score;

    private float speed = 0.2f;
    public int health = 5;

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
        Vector2 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        mousePos.y = -4.57f;
        transform.position = mousePos;

        if (Input.GetMouseButtonDown(0))
        {
            switch (actualWeapon)
            {
                case Weapons.ClassicBullet:
                    Instantiate(bullet, parent.position, parent.rotation);
                    break;
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

        Debug.Log(timerLaserAbility);

        if (decreaseTimerLaser)
        {
            if (timerLaserAbility < 1.5f)
            {
                timerLaserAbility += Time.deltaTime;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space) && score >= 10)
        {
            actualWeapon = Weapons.DoubleBullet;

            score -= 10;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && score >= 10)
        {
            actualWeapon = Weapons.Laser;

            score -= 10;

            decreaseTimerLaser = true;
        }
    }
}

public enum Weapons
{
    ClassicBullet,
    DoubleBullet,
    Laser
}
