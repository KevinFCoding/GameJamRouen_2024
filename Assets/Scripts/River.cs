using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class River : MonoBehaviour
{

    // state false -> Normandie
    //State true -> Bretagne
    public bool _currentState;
    [SerializeField] SpriteRenderer _spriteRiver;
    void Start()
    {
        _spriteRiver.flipX = false;
    }

    public void ChangeState()
    {
        if(_currentState == false)
        {
            // Normandie Attaque / Bretagne D�fend
            _spriteRiver.flipX = false; 
        }
        else
        {
            // Bretagne Attaque / Normandie D�fend
            _spriteRiver.flipX = true;

        }
    }

}
