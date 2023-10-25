using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    public GameObject bullet;
    public Transform parent;
    public Transform limitL;
    public Transform limitR;
    public int score;

    private float speed = 0.2f;
    public int health = 5;

    public Weapons actualWeapon = Weapons.ClassicBullet;

    public int alienRemain = 48;

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

        /*if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left*speed;
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right*speed;
        }

        if(transform.position.x < limitL.position.x)
        {
            transform.position = new Vector3(limitR.position.x, transform.position.y, transform.position.z);
        }
        if (transform.position.x > limitR.position.x)
        {
            transform.position = new Vector3(limitL.position.x, transform.position.y, transform.position.z);
        }*/

        if (Input.GetMouseButtonDown(0))
        {
            switch (actualWeapon)
            {
                case Weapons.ClassicBullet:
                    Instantiate(bullet, parent.position, parent.rotation);
                    break;
                case Weapons.DoubleBullet:

                    for (int i = 0; i < 2; i++)
                    {
                        Instantiate(bullet, parent.position, parent.rotation);
                    }
                    break;
                default:
                    break;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space) && score >= 10)
        {
            actualWeapon = Weapons.DoubleBullet;
        }
    }
}

public enum Weapons
{
    ClassicBullet,
    DoubleBullet
}
