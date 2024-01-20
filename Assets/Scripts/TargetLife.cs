using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;

public class TargetLife : MonoBehaviour
{

    [SerializeField] int _maxHP = 100;
    public float currentHP;
    [SerializeField] int _damage;
    [SerializeField] PauseManager _pauseManager;
    [SerializeField] GameManager _gameManager;
    [SerializeField] PostProcessVolume _vignette;
    [SerializeField] CameraShaking _cameraShaking;


    [SerializeField] Slider _lifeBarSlider;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Projectile>())
        {
            TakeDamage();
            Destroy(collision.gameObject);
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
            TakeDamage();
        }
    }

    public void TakeDamage()
    {
        currentHP -= _damage;
        UpdateSliderLifeBar();
        _cameraShaking.shakeshake = true;
        
    }

    public void UpdateSliderLifeBar()
    {
        _lifeBarSlider.value = currentHP/100;
        _vignette.weight += 0.10f;
    }
}
