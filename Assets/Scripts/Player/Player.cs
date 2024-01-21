using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class Player : MonoBehaviour
{
    public GameManager gm;

    [SerializeField] Transform _target;
    [SerializeField] bool _isNormand;
    [SerializeField] List<Projectile> _projectile;
    [SerializeField] List<GameObject> _MiniatureImage;

    [SerializeField] float _speed;
    [SerializeField] float _distanceRadius;

    [SerializeField] bool _isAttacking;
    [SerializeField] Transform _arrowMuzzle;

    private float shootTimer;

    private int assaultTableCurrentIndex = 0;

    private void Start()
    {
        transform.position = _target.transform.position;
        changePlayerAttacking();
        _arrowMuzzle = gameObject.GetComponentInChildren<ArrowMuzzle>().transform;
        nextTroupes();
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
            _distanceRadius = 5;
            _speed = 5;
            _isAttacking = false; 
        };
        // Normand Attack
        if (_isNormand && gm.getStatusAttack())
        {
            _distanceRadius = 15;
            _speed = 10;
            _isAttacking = true;
        };
        // Breton Def
        if (!_isNormand && gm.getStatusAttack())
        {
            _distanceRadius = 5;
            _speed = 5;
            _isAttacking = false;
        };
        // Breton Attack
        if (!_isNormand && !gm.getStatusAttack())
        {
            _distanceRadius = 15;
            _speed = 10;
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
            Projectile shotFired = Instantiate(getCurrentProjectileSelected(), _arrowMuzzle.position, _arrowMuzzle.rotation);
            Destroy(shotFired, 3f);
            shootTimer = 0;
        }
    }

    private Projectile getCurrentProjectileSelected()
    {
        return _projectile[assaultTableCurrentIndex];
    }

    public float getRadius()
    {
        return _distanceRadius;
    }

    public float getSpeed()
    {
        return _speed;
    }

    public Vector3 getTargetPosition()
    {
        return _target.position;
    }

    public void nextTroupes()
    {
        if (assaultTableCurrentIndex == 2) {
            assaultTableCurrentIndex = 0;
        } else
        {
            assaultTableCurrentIndex++;
        }
        foreach (GameObject image in _MiniatureImage)
        {
            if (getCurrentProjectileSelected().name == image.name) {
                image.SetActive(true);
            }
            if (getCurrentProjectileSelected().name != image.name)
            {
                image.SetActive(false);
            }
        }
        
    }

    // Collision with bullet from attack
    private void OnTriggerEnter(Collider collider)
    {
        if(!isPlayerAttacking())
        {
            if (collider.gameObject.GetComponent<Projectile>())
            {
                if (IsTheDefenserRight(collider.gameObject.GetComponent<Projectile>().getProjectileStyle()))
                {
                    Destroy(collider.gameObject);
                }
                collider.gameObject.GetComponent<Projectile>().Reduced();
            }
        }
    }

    private bool IsTheDefenserRight(string nameAttacker)
    {
        if (nameAttacker == "Knight")
        {
            if (getCurrentProjectileSelected().name == "Lancer") { return true; }
            else { return false; }
        }
        if (nameAttacker == "Archer") { 
            if (getCurrentProjectileSelected().name == "Knight") { return true; }
            else { return false; }
        }
        if (nameAttacker == "Lancer")
        {
            if (getCurrentProjectileSelected().name == "Archer") { return true; }
            else { return false; }
        }
        return false;
    }
}   
