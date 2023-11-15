using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour
{
    public Player myPlayer;
    public Rigidbody2D bonusRigibody;
    public VariableLibrary library;

    public float speedBonus;
    private float currentSpeedBonus;

    // Start is called before the first frame update
    void Start()
    {
        myPlayer = FindAnyObjectByType<Player>();
        library = FindObjectOfType<VariableLibrary>();
    }

    // Update is called once per frame
    void Update()
    {
        // si le bonus sort de l'écran, il disparaît
        if (transform.position.y < library.limitB.position.y)
        {
            Destroy(gameObject);
        }

        // si le menu de pause du joueur est activé, le bonus cesse de tomber

        bonusRigibody.velocity = Vector3.down * currentSpeedBonus;
        
        if (myPlayer.pauseMenu)
        {
            currentSpeedBonus = 0;
        }
        else
        {
            currentSpeedBonus = speedBonus;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // si le bonus trigger le player, il disparaît et incrémente son score
        myPlayer = collision.gameObject.GetComponent<Player>();
        if (myPlayer == true)
        {
            myPlayer.score++;
            Destroy(gameObject);
        }
    }
}
