using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float _speed;
    public GameObject projectile;

    void Update()
    {
        transform.position += Time.deltaTime * _speed * transform.forward;
    }
}
