using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Transform _target;
    [SerializeField] GameManager _gm;
    private bool _isAttacking;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(_target);
    }

    private void changePlayerAttacking()
    {
        //_gm.
    } 
    public bool isPlayerAttacking()
    {
        return _isAttacking;
    }

    public void Fire()
    {

    }
}
