using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunctionLibrary : MonoBehaviour
{
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
}
