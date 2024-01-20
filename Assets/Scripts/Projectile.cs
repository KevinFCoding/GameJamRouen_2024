using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float _speed;
    [SerializeField] string _projectileStyle;
    public GameObject projectile;
    public float arrowDirection = 1;

    void Update()
    {
        transform.position += Time.deltaTime * _speed * transform.forward * arrowDirection;
    }

    public string getProjectileStyle()
    {
        return _projectileStyle;
    }
}
