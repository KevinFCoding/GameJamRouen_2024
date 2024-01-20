using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.UI;

public class TargetLife : MonoBehaviour
{

    [SerializeField] int _maxHP = 10;
    public float currentHP;
    [SerializeField] int _damage;
    [SerializeField] PauseManager _pauseManager;
    [SerializeField] GameManager _gameManager;

    [SerializeField] Slider _lifeBarSlider;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.GetComponent<Projectile>())
        {

            if (collider.gameObject.GetComponent<Projectile>().getIsReduced())
            {
                TakeDamage(1);
            }
            TakeDamage(2);
            Destroy(collider.gameObject);
        }
    }
    void Start()
    {
        currentHP = _maxHP;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H) && !_pauseManager.gameIsPaused && !_gameManager.gameIsFinished)
        {
            TakeDamage(5);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHP -= damage;
        UpdateSliderLifeBar();
    }

    public void UpdateSliderLifeBar()
    {
        _lifeBarSlider.value = currentHP / 100;
    }
}
