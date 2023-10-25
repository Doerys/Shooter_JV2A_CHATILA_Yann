using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour
{
    public Player myPlayer;
    public Rigidbody2D bonusRigibody;
    public VariableLibrary library;

    // Start is called before the first frame update
    void Start()
    {
        myPlayer = gameObject.GetComponent<Player>();
        bonusRigibody.velocity = new Vector2(0, -5);
        library = FindObjectOfType<VariableLibrary>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < library.limitB.position.y)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        myPlayer = collision.gameObject.GetComponent<Player>();
        if (myPlayer == true)
        {
            myPlayer.score++;
            Destroy(gameObject);
        }
    }
}
