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
    //[SerializeField] List<Projectile> _projectile;
    [SerializeField] Projectile _projectile;
    //[SerializeField] List<GameObject> _MiniatureImage;

    [SerializeField] float _defenseSpeed;
    [SerializeField] float _speed;
    [SerializeField] float _distanceRadius;

    [SerializeField] bool _isAttacking;
    [SerializeField] Transform _arrowMuzzle;

    private float shootTimer;

    private int assaultTableCurrentIndex = 0;

    [SerializeField] AudioClip _positionSwapSound;
    [SerializeField] List<AudioClip> _attackSound;
    [SerializeField] List<AudioClip> _defenseSound;
    [SerializeField] ParticleSystem _ParticleSystem;

    [SerializeField] GameObject _bow;
    [SerializeField] GameObject _shield;
    [SerializeField] GameObject _arrow;

    private AudioSource _playerAudioSource;


    private void Start()
    {
        transform.position = _target.transform.position;
        _playerAudioSource = GetComponent<AudioSource>();
        changePlayerAttacking();
        _arrowMuzzle = gameObject.GetComponentInChildren<ArrowMuzzle>().transform;
        nextTroupes();
    }

    void Update()
    {
        transform.LookAt(_target);
        changePlayerAttacking();
        shootTimer += Time.deltaTime;
        if (shootTimer > 2 && _arrow.active == false && _isAttacking) {
            _arrow.SetActive(true);
        }
    }

    private void changePlayerAttacking()
    {
        if(_isAttacking)
        {
            if(!_bow.active)
            {
                _bow.SetActive(true);
            }
            if (_shield.active)
            {
                _shield.SetActive(false);
            }
        } else {
            if (_bow.active)
            {
                _bow.SetActive(false);
            }
            if (!_shield.active)
            {
                _shield.SetActive(true);
            }
            if(_arrow.active) {
                _arrow.SetActive(false);
            }
        }

        // Normand Defend
        if(_isNormand && !gm.getStatusAttack()) // If false the Normand have montsaitnniche,
        {
            _distanceRadius = 4;
            _speed = 4;
            _isAttacking = false; 
        };
        // Normand Attack
        if (_isNormand && gm.getStatusAttack())
        {
            _distanceRadius = 16;
            _speed = 4.5f;
            _isAttacking = true;
        };
        // Breton Def
        if (!_isNormand && gm.getStatusAttack())
        {
            _distanceRadius = 4;
            _speed = 4;
            _isAttacking = false;
        };
        // Breton Attack
        if (!_isNormand && !gm.getStatusAttack())
        {
            _distanceRadius = 16;
            _speed = 4.5f;
            _isAttacking = true;
        };
         // Avoid direct shoot after switch
    } 

    public bool isPlayerAttacking()
    {
        return _isAttacking;
    }

    public void Fire()
    {
        if(shootTimer > 2) { 
            Projectile shotFired = Instantiate(_projectile, _arrowMuzzle.position, _arrowMuzzle.rotation);
            Destroy(shotFired, 3f);
            shootTimer = 0;

            _arrow.SetActive(false);
            int soundToPlay = Random.Range(0, _attackSound.Count);
            _playerAudioSource.PlayOneShot(_attackSound[soundToPlay]);
        }
    }

    //private Projectile getCurrentProjectileSelected()
    //{
    //    return _projectile[assaultTableCurrentIndex];
    //}

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
        //if (assaultTableCurrentIndex == 2) {
        //    assaultTableCurrentIndex = 0;
        //} else
        //{
        //    assaultTableCurrentIndex++;
        //}
        //foreach (GameObject image in _MiniatureImage)
        //{
        //    if (getCurrentProjectileSelected().name == image.name) {
        //        image.SetActive(true);
        //    }
        //    if (getCurrentProjectileSelected().name != image.name)
        //    {
        //        image.SetActive(false);
        //    }
        //}
        
    }

    // Collision with bullet from attack
    private void OnTriggerEnter(Collider collider)
    {
        if(!isPlayerAttacking())
        {
            if (collider.gameObject.GetComponent<Projectile>())
            {
                //if (IsTheDefenserRight(collider.gameObject.GetComponent<Projectile>().getProjectileStyle()))
                //{
                Destroy(collider.gameObject);
                int soundToPlay = Random.Range(0, _defenseSound.Count);
                _playerAudioSource.PlayOneShot(_defenseSound[soundToPlay]);
                _ParticleSystem.Play();

                //}
                //collider.gameObject.GetComponent<Projectile>().Reduced();
            }
        }
    }

    //private bool IsTheDefenserRight(string nameAttacker)
    //{
    //    if (nameAttacker == "Knight")
    //    {
    //        if (getCurrentProjectileSelected().name == "Lancer") { return true; }
    //        else { return false; }
    //    }
    //    if (nameAttacker == "Archer") { 
    //        if (getCurrentProjectileSelected().name == "Knight") { return true; }
    //        else { return false; }
    //    }
    //    if (nameAttacker == "Lancer")
    //    {
    //        if (getCurrentProjectileSelected().name == "Archer") { return true; }
    //        else { return false; }
    //    }
    //    return false;
    //}
}   
