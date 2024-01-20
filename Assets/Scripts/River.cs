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
        
    }

    void Update()
    {
        
    }

    public void ChangeState()
    {
        if(_currentState == false)
        {
            // Normandie Attaque / Bretagne D�fend
            _spriteRiver.flipX = true; 
        }
        else
        {
            // Bretagne Attaque / Normandie D�fend
            _spriteRiver.flipX = false;

        }
    }

}
