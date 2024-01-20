using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{

    [SerializeField] GameObject _pauseCanvas;
    [SerializeField] bool _gameIsPaused;
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }

    }

    public void Pause()
    {
        if (_gameIsPaused == true)
        {
            _pauseCanvas.SetActive(false);
            Time.timeScale = 1;
            _gameIsPaused = false;

        }
        else
        {
            _pauseCanvas.SetActive(true);
            Time.timeScale = 0;
            _gameIsPaused = true;


        }
    }

    public void ClosePauseMenu()
    {
        _pauseCanvas.SetActive(false);
    }
}
