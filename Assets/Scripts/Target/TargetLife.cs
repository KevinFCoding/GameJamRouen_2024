using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLife : MonoBehaviour
{

    [SerializeField] int _maxHP = 100;
    [SerializeField] int _currentHP;
    [SerializeField] int _damage;
    void Start()
    {
        _currentHP = _maxHP;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            TakeDamage();
        }
    }

    public void TakeDamage()
    {
        _currentHP -= _damage;
    }
}
