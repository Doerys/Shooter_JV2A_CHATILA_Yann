using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialWeapon : MonoBehaviour
{
    private Player myPlayer;

    private float timer;

    private FunctionLibrary functionLibrary;

    Vector3 positionWeapon;

    // Start is called before the first frame update
    void Start()
    {
        myPlayer = FindObjectOfType<Player>();

        functionLibrary = FindAnyObjectByType<FunctionLibrary>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 2f)
        {
            Destroy(gameObject);
        }

        positionWeapon = myPlayer.transform.position;

        if (gameObject.tag == "laser")
        {
            positionWeapon.y = myPlayer.transform.position.y + 2;
        }

        else
        {
            positionWeapon.y = myPlayer.transform.position.y;
        }

        transform.position = positionWeapon;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        functionLibrary.CheckTriggerSpecialWeapon(collision);

        if (gameObject.tag == "shield")
        {
            Bullet myTarget = collision.gameObject.GetComponent<Bullet>();

            if (myTarget != null)
            {
                Destroy(collision.gameObject);
            }
        }
    }
}
