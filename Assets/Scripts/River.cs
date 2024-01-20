using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class River : MonoBehaviour
{

    [SerializeField] bool _state; 
    // state false -> Normandie
    //State true -> Bretagne
    [SerializeField] bool _currentState;
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
            // Normandie Attaque / Bretagne Défend
            _spriteRiver.flipX = true; 
        }
        else
        {
            // Bretagne Attaque / Normandie Défend
            _spriteRiver.flipX = false;

        }
    }

}
