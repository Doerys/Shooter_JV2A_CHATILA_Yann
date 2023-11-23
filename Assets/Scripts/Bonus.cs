using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour
{
    public FunctionLibrary functionLibrary;
    public Player myPlayer;
    public Rigidbody2D bonusRigibody;
    public VariableLibrary library;

    public float speedBonus;
    public float currentSpeedBonus;

    public Vector3 bonusDirection = Vector3.down;

    // Start is called before the first frame update
    void Start()
    {
        myPlayer = FindAnyObjectByType<Player>();
        library = FindAnyObjectByType<VariableLibrary>();
        functionLibrary = FindAnyObjectByType<FunctionLibrary>();
        bonusRigibody = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // si le bonus sort de l'�cran, il dispara�t
        if (transform.position.y < library.limitB.position.y)
        {
            Destroy(gameObject);
        }

        if (!myPlayer.isAlive)
        {
            Destroy(gameObject);
        }

        // si le menu de pause du joueur est activ�, le bonus cesse de tomber
        functionLibrary.Move(myPlayer, currentSpeedBonus, speedBonus, bonusRigibody, bonusDirection);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // si le bonus trigger le player, il dispara�t et incr�mente son score
        Player myPlayerCollision = collision.gameObject.GetComponent<Player>();
        if (myPlayerCollision != null)
        {
            myPlayerCollision.energy++;
            Destroy(gameObject);
        }
    }
}
