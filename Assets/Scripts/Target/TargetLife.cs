using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLife : MonoBehaviour
{

    [SerializeField] int _maxHP = 100;
    public int currentHP;
    [SerializeField] int _damage;
    [SerializeField] PauseManager _pauseManager;
    [SerializeField] GameManager _gameManager;
    void Start()
    {
        currentHP = _maxHP;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H) && !_pauseManager.gameIsPaused && !_gameManager.gameIsFinished)
        {
            TakeDamage();
        }
    }

    public void TakeDamage()
    {
        currentHP -= _damage;
    }
}
