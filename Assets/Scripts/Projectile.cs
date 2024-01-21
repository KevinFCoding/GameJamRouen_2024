using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float _speed;
    [SerializeField] string _projectileStyle;

    private bool _isReduced = false;

    void Update()
    {
        transform.position += Time.deltaTime * _speed * transform.forward;
    }

    public string getProjectileStyle()
    {
        return _projectileStyle;
    }

    public void Reduced()
    {
        _isReduced = true;
    }

    public bool getIsReduced()
    {
        return _isReduced;
    }
}
