using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;

public class TargetLife : MonoBehaviour
{

    [SerializeField] int _maxHP = 20;
    public float currentHP;
    [SerializeField] int _damage;
    [SerializeField] PauseManager _pauseManager;
    [SerializeField] GameManager _gameManager;
    [SerializeField] PostProcessVolume _vignette;
    [SerializeField] CameraShaking _cameraShaking;
    [SerializeField] List<GameObject> _spritesTarget;

    

    [SerializeField] Slider _lifeBarSlider;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.GetComponent<Projectile>())
        {

            if (collider.gameObject.GetComponent<Projectile>().getIsReduced())
            {
                TakeDamage(1);
            }
            else
            {
                TakeDamage(2);
            }
            Destroy(collider.gameObject);
        }
    }
    void Start()
    {
        currentHP = _maxHP;
        foreach (var sprite in _spritesTarget)
        {
            sprite.gameObject.SetActive(false);
        }
        _spritesTarget[0].SetActive(true);
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
        _cameraShaking.shakeshake = true;

        if (currentHP < 6) {
            _spritesTarget[1].SetActive(true);
            _spritesTarget[0].SetActive(false);
        }
        if (currentHP < 3)
        {
            _spritesTarget[2].SetActive(true);
            _spritesTarget[1].SetActive(false);
        }
        _vignette.weight += damage / 100;
    }

    public void UpdateSliderLifeBar()
    {
        _lifeBarSlider.value = currentHP / 10;
    }
}
