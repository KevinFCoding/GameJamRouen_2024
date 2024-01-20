using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Transform _target;
    [SerializeField] bool _isNormand;
    [SerializeField] Projectile _projectile;
    [SerializeField] float _speed;

    [SerializeField] float _distanceRadius;

    public GameManager gm;

    [SerializeField] bool _isAttacking;
    private float shootTimer;


    void Update()
    {
        transform.LookAt(_target);
        if (gm.getStatusAttack() != _isAttacking)
        {
            changePlayerAttacking();
        }
        shootTimer += Time.deltaTime;
    }

    private void changePlayerAttacking()
    {
        // Normand Attack
        if(_isNormand && gm.getStatusAttack())
        {
            _distanceRadius = 15;
            _isAttacking = false; 
        };
        // Normand Defend
        if (_isNormand && !gm.getStatusAttack())
        {
            _distanceRadius = 8;
            _isAttacking = true;
        };
        // Breton Attack
        if (!_isNormand && !gm.getStatusAttack())
        {
            _distanceRadius = 15;
            _isAttacking = true;
        };
        // Breton Defend
        if (!_isNormand && !gm.getStatusAttack())
        {
            _distanceRadius = 8;
            _isAttacking = false;
        };
    } 

    public bool isPlayerAttacking()
    {
        return _isAttacking;
    }

    public void Fire()
    {
        if(shootTimer > 2) { 
            Projectile shotFired = Instantiate(_projectile, transform.localPosition, transform.rotation);
            Destroy(shotFired, 5f);
            shootTimer = 0;
        }
    }

    public float getRadius()
    {
        return _distanceRadius;
    }

    public float getSpeed()
    {
        return _speed;
    }

}
