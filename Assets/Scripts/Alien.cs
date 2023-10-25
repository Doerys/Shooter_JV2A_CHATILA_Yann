using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : MonoBehaviour
{

    public Rigidbody2D myRigidbody;

    public int remainHealth;

    // Start is called before the first frame update
    void Start()
    {

        myRigidbody.velocity = new Vector2(0, -0.05f);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
