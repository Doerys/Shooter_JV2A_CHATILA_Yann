using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunctionLibrary : MonoBehaviour
{
    public GameObject bonusPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Move (Player _myPlayer, float _currentSpeed, float _speed, Rigidbody2D _rigidbody, Vector3 _direction) {

        _currentSpeed = Pause(_myPlayer, _speed);

        _rigidbody.velocity = _direction * _currentSpeed;
    }

    public float Pause (Player _myPlayer, float _speed)
    {

        if (_myPlayer.pauseMenu)
        {
            //Debug.Log("VITESSE NULLE = " + _currentSpeed
            return 0;
        }

        else
        {
            //Debug.Log("VITESSE NORMALE = " + _currentSpeed
            return _speed;
        }
    }

    public void CheckTrigger(Collider2D _collision)
    {
        Alien myTarget = _collision.gameObject.GetComponent<Alien>();

        if (myTarget != null)
        {
            Debug.Log("CONTACT");

            myTarget.remainHealth -= 3;

            if (myTarget.remainHealth <= 0)
            {
                Destroy(_collision.gameObject);

                int spawnProbability = Random.Range(1, 3);

                if (spawnProbability < 2)
                {
                    Instantiate(bonusPrefab, _collision.gameObject.transform.position, _collision.gameObject.transform.rotation);
                }
            }
        }
    }
}
