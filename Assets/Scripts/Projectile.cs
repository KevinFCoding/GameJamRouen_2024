using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float _speed;
    public GameObject projectile;
    public float arrowDirection = 1;

    void Update()
    {
        transform.position += Time.deltaTime * _speed * transform.forward * arrowDirection;
    }

    public void setArrowSens()
    {
        arrowDirection = arrowDirection * - 1;
    }
}
