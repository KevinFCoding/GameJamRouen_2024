using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Transform _target;
    [SerializeField] GameManager _gm;
    [SerializeField] bool _isNormand;

    private bool _isAttacking;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(_target);
        if (_gm.getStatusAttack() != _isAttacking)
        {
            changePlayerAttacking();
        }
    }

    private void changePlayerAttacking()
    {
        if(_isNormand && _gm.getStatusAttack())
        {
            _isAttacking = false; 
        };
        if (!_isNormand && !_gm.getStatusAttack())
        {
            _isAttacking = false;
        };
        if (!_isNormand && _gm.getStatusAttack())
        {
            _isAttacking = true;
        };
        if (!_isNormand && !_gm.getStatusAttack())
        {
            _isAttacking = true;
        };
    } 

    public bool isPlayerAttacking()
    {
        return _isAttacking;
    }

    public void Fire()
    {

    }
}
