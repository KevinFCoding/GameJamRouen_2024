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

    public Transform _arrowMuzzle;

    private void Start()
    {
        changePlayerAttacking();
        _arrowMuzzle = gameObject.GetComponentInChildren<ArrowMuzzle>().transform;
    }

    void Update()
    {
        transform.LookAt(_target);
        changePlayerAttacking();
        shootTimer += Time.deltaTime;
    }

    private void changePlayerAttacking()
    {
        // Normand Defend
        if(_isNormand && !gm.getStatusAttack()) // If false the Normand have montsaitnniche,
        {
            _distanceRadius = 8;
            _isAttacking = false; 
        };
        // Normand Attack
        if (_isNormand && gm.getStatusAttack())
        {
            _distanceRadius = 15;
            _isAttacking = true;
        };
        // Breton Def
        if (!_isNormand && gm.getStatusAttack())
        {
            _distanceRadius = 8;
            _isAttacking = false;
        };
        // Breton Attack
        if (!_isNormand && !gm.getStatusAttack())
        {
            _distanceRadius = 15;
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
            Projectile shotFired = Instantiate(_projectile, _arrowMuzzle.position, _arrowMuzzle.rotation);
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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Projectile>())
        {
            Destroy(collision.gameObject);
        }
    }
}   
