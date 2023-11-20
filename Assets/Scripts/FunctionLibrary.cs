using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class FunctionLibrary : MonoBehaviour
{
    public GameObject bonusPrefab;

    public ParticleSystem prefabExplosionParticleEmitter;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Je check si la pause est pressée, et si non, je rajoute de la vélocité.
    public void Move (Player _myPlayer, float _currentSpeed, float _speed, Rigidbody2D _rigidbody, Vector3 _direction) {

        _currentSpeed = Pause(_myPlayer, _speed);

        _rigidbody.velocity = _direction * _currentSpeed;
    }


    // Si le bouton pause est pressé, la vitesse est nulle
    public float Pause (Player _myPlayer, float _speed)
    {

        if (_myPlayer.pauseMenu)
        {
            return 0;
        }

        else
        {
            return _speed;
        }
    }

    // si un alien trigger, on lui enlève de la vie
    public void CheckTriggerWeapon(Collider2D _collision)
    {
        Alien myTarget = _collision.gameObject.GetComponent<Alien>();

        if (myTarget != null)
        {
            myTarget.remainHealth -= 1;

            checkEnemyDeath(myTarget);
        }
    }

    // si un alien trigger, on lui enlève de la vie
    public void CheckTriggerSpecialWeapon(Collider2D _collision)
    {
        Alien myTarget = _collision.gameObject.GetComponent<Alien>();

        if (myTarget != null)
        {
            myTarget.remainHealth -= 3;

            checkEnemyDeath(myTarget);
        }
    }

    // Si un alien n'a plus de vie, on le tue
    public void checkEnemyDeath(Alien _myTarget)
    {
        if (_myTarget.remainHealth <= 0)
        {
            Instantiate(prefabExplosionParticleEmitter, _myTarget.gameObject.transform.position, _myTarget.gameObject.transform.rotation);

            Destroy(_myTarget.gameObject);

            int spawnProbability = Random.Range(1, 3);

            if (spawnProbability < 2)
            {
                Instantiate(bonusPrefab, _myTarget.gameObject.transform.position, _myTarget.gameObject.transform.rotation);
            }
        }
    }
}
