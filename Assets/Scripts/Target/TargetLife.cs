using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetLife : MonoBehaviour
{

    [SerializeField] int _maxHP = 100;
    public float currentHP;
    [SerializeField] int _damage;
    [SerializeField] PauseManager _pauseManager;
    [SerializeField] GameManager _gameManager;

    [SerializeField] Slider _lifeBarSlider;
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
        UpdateSliderLifeBar();
    }

    public void UpdateSliderLifeBar()
    {
        _lifeBarSlider.value = currentHP/100;
    }
}
