using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Transform _target;
    [SerializeField] GameManager _gm;
    [SerializeField] bool _isNormand;

    [SerializeField] Projectile _projectile;

    private bool _isAttacking;
    private float shootTimer;

    void Update()
    {
        transform.LookAt(_target);
        if (_gm.getStatusAttack() != _isAttacking)
        {
            changePlayerAttacking();
        }
        shootTimer += Time.deltaTime;
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
        if(shootTimer > 2) { 
            Debug.Log("asdkojasjkhdashjkdhjkasdjkhasdjkhas");
            Projectile shotFired = Instantiate(_projectile, transform, true);
            Destroy(shotFired, 5f);
            shootTimer = 0;
        }
    }
}
